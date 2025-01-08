using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Contributors;

public sealed record CreateContributorRequest(Guid UserId, string FirstName, string LastName);

public sealed record CreateContributorResponse(Guid Id, string FullName);

public sealed class CreateContributorEndpoint(DeerliciousContext context)
    : Endpoint<CreateContributorRequest, CreateContributorResponse>
{
    public override void Configure()
    {
        Post("api/contributors");
        Policies(nameof(UserPolicies.CanCreateContributor));
        Options(x => x.WithTags("Contributors"));
    }

    public override async Task HandleAsync(CreateContributorRequest request, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

        if (user is null)
            ThrowError(ErrorMessages.NotFound);

        var newContributor = Contributor.Create(user, request.FirstName, request.LastName);

        context.Contributors.Add(newContributor);

        var result = await context.SaveChangesAsync(cancellationToken);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new CreateContributorResponse(newContributor.Id, newContributor.FullName),
            cancellation: cancellationToken);
    }
}

public sealed class CreateContributorRequestValidator : Validator<CreateContributorRequest>
{
    public CreateContributorRequestValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.LastName).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}