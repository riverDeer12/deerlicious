using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Roles;

public sealed record GetRolePermissionResponse(Guid PermissionId, string Name, string Description);

public sealed class GetRolePermissionsEndpoint : EndpointWithoutRequest<List<GetRolePermissionResponse>>
{
    private readonly DeerliciousContext _context;

    public GetRolePermissionsEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get("api/roles/{id}/permissions");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Roles"));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var roleId = Route<Guid>("id", isRequired: true);

        var rolePermissions = await _context.RolePermissions
            .Where(x => x.RoleId == roleId)
            .Include(x => x.Role)
            .Include(x => x.Permission)
            .ToListAsync(cancellationToken: cancellationToken);

        if (rolePermissions.Count == 0)
                {
        await SendAsync([], cancellation: cancellationToken);
        return;
    }

        await SendAsync(rolePermissions
            .Select(x => new GetRolePermissionResponse(x.PermissionId, x.Permission.Name, x.Permission.Description))
            .ToList(), cancellation: cancellationToken);
    }
}