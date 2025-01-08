using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Features.Administrators;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Roles;

public sealed record GetRoleResponse(Guid RoleId, string RoleName);

public sealed class GetRolesEndpoint(DeerliciousContext context) : EndpointWithoutRequest<List<GetRoleResponse>>
{
    public override void Configure()
    {
        Get("api/roles");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Roles"));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var roles = await context.Roles.ToListAsync(cancellationToken: cancellationToken);

        if (roles.Count is 0)
            await SendAsync([], cancellation: cancellationToken);

        await SendAsync(roles
            .Select(x => new GetRoleResponse(x.Id, x.Name))
            .ToList(), cancellation: cancellationToken);
    }
}