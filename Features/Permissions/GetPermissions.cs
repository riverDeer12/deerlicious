using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Permissions;

public sealed record GetPermissionResponse(Guid Id, string Name, string Description, string Category);

public sealed class GetPermissionsEndpoint : EndpointWithoutRequest<List<GetPermissionResponse>>
{
    private readonly DeerliciousContext _context;

    public GetPermissionsEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get("api/permissions");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Permissions"));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var permissions = await _context.Permissions.ToListAsync(cancellationToken: cancellationToken);

        await SendAsync(permissions
            .Select(x => new GetPermissionResponse(x.Id, x.Name, x.Description, x.Category))
            .ToList(), cancellation: cancellationToken);
    }
}