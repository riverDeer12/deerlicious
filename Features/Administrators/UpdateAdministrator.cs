using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Administrators;

public sealed record UpdateAdministratorRequest(string FirstName, string LastName);

public sealed record UpdateAdministratorResponse(Guid Id, string FullName);

public class UpdateAdministratorEndpoint(DeerliciousContext context)
    : Endpoint<UpdateAdministratorRequest, UpdateAdministratorResponse>
{
    public override void Configure()
    {
        Put("api/administrators/{id}");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Administrators"));
    }

    public override async Task HandleAsync(UpdateAdministratorRequest request, CancellationToken cancellationToken)
    {
        var administratorId = Route<Guid>("id", isRequired: true);

        var administrator =
            await context.Administrators
                .FirstOrDefaultAsync(x => x.Id == administratorId, cancellationToken: cancellationToken);

        if (administrator is null)
            ThrowError(ErrorMessages.NotFound);

        administrator.FirstName = request.FirstName;
        administrator.LastName = request.LastName;

        context.Administrators.Update(administrator);

        var result = await context.SaveChangesAsync(cancellationToken);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new(administrator.Id, administrator.FullName), cancellation: cancellationToken);
    }
}

public sealed class UpdateAdministratorValidator : Validator<UpdateAdministratorRequest>
{
    public UpdateAdministratorValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.LastName).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.LastName).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}