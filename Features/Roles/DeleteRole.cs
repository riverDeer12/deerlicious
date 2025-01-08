using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Features.Contributors;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Roles;

public sealed record DeleteRoleResponse(Guid Id, string RoleName);

public class DeleteRoleEndpoint(DeerliciousContext context) : EndpointWithoutRequest<DeleteRoleResponse>
{
    public override void Configure()
    {
        Delete("api/roles/{id}");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Roles"));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var roleId = Route<Guid>("id", isRequired: true);

        var role =
            await context.Roles
                .FirstOrDefaultAsync(x => x.Id == roleId, cancellationToken: cancellationToken);

        if (role is null)
            ThrowError(ErrorMessages.NotFound);

        role.Delete();

        context.Roles.Update(role);

        var result = await context.SaveChangesAsync(cancellationToken);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new DeleteRoleResponse(role.Id, role.Name), cancellation: cancellationToken);
    }
}