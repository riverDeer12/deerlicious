using FastEndpoints;
using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Administrators;

public sealed record CreateAdministratorRequest(Guid UserId, string FirstName, string LastName);
public sealed record CreateAdministratorResponse(Guid Id, string FullName);

public sealed class CreateAdministratorEndpoint(DeerliciousContext context)
    : Endpoint<CreateAdministratorRequest, CreateAdministratorResponse>
{
    public override void Configure()
    {
        Post("api/administrators");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Administrators"));
    }

    public override async Task HandleAsync(CreateAdministratorRequest request, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

        if (user is null)
            ThrowError(ErrorMessages.NotFound);

        var newAdministrator = Administrator.Create(user, request.FirstName, request.LastName);

        context.Administrators.Add(newAdministrator);

        var result = await context.SaveChangesAsync(cancellationToken);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new CreateAdministratorResponse(newAdministrator.Id, newAdministrator.FullName),
            cancellation: cancellationToken);
    }
}

public sealed class CreateAdministratorValidator : Validator<CreateAdministratorRequest>
{
    public CreateAdministratorValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.LastName).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}