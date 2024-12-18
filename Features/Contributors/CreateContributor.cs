using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Contributors;

public sealed record CreateContributorRequest(string FirstName, string LastName, string Email);

public sealed record CreateContributorResponse(Guid Id, string FullName);

public sealed class CreateContributorEndpoint : Endpoint<CreateContributorRequest, CreateContributorResponse>
{
    private readonly DeerliciousContext _context;

    public CreateContributorEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post("api/contributors");
        AllowAnonymous();
        Options(x => x.WithTags("Contributors"));
    }

    public override async Task HandleAsync(CreateContributorRequest request, CancellationToken ct)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email, ct);

        if (user is null)
            ThrowError(ValidationMessages.NotFound);

        var newContributor = Contributor.Create(request.FirstName, request.LastName);

        _context.Contributors.Add(newContributor);

        var result = await _context.SaveChangesAsync(ct);

        if (result is not 1)
            ThrowError(ValidationMessages.SavingError);

        await SendAsync(new CreateContributorResponse(newContributor.Id, newContributor.FullName),
            cancellation: ct);
    }
}

public sealed class CreateContributorRequestValidator : AbstractValidator<CreateContributorRequest>
{
    public CreateContributorRequestValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
    }
}