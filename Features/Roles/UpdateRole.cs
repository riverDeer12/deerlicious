using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Roles;

public sealed record UpdateRoleRequest(string RoleName);

public sealed record UpdateRoleResponse(Guid Id, string FullName);

public class UpdateRoleEndpoint(DeerliciousContext context) : Endpoint<UpdateRoleRequest, UpdateRoleResponse>
{
    public override void Configure()
    {
        Put("api/roles/{id}");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Roles"));
    }

    public override async Task HandleAsync(UpdateRoleRequest request, CancellationToken cancellationToken)
    {
        var roleId = Route<Guid>("id", isRequired: true);

        var role =
            await context.Roles
                .FirstOrDefaultAsync(x => x.Id == roleId, cancellationToken: cancellationToken);

        if (role is null)
            ThrowError(ErrorMessages.NotFound);

        role.Name = request.RoleName;

        context.Roles.Update(role);

        var result = await context.SaveChangesAsync(cancellationToken);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new UpdateRoleResponse(role.Id, role.Name), cancellation: cancellationToken);
    }
}

public sealed class UpdateRoleValidator : Validator<UpdateRoleRequest>
{
    public UpdateRoleValidator()
    {
        RuleFor(x => x.RoleName).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}