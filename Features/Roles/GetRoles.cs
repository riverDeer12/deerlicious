using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Features.Administrators;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Roles;

public sealed record GetRoleResponse(
    Guid Id,
    string Name,
    string Description,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt,
    bool IsDeleted);

public sealed class GetRolesEndpoint : EndpointWithoutRequest<List<GetRoleResponse>>
{
    private readonly DeerliciousContext _context;

    public GetRolesEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get("api/roles");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Roles"));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var roles = await _context.Roles.ToListAsync(cancellationToken: cancellationToken);

        if (roles.Count is 0)
        {
            await SendAsync([], cancellation: cancellationToken);
            return;
        }

        await SendAsync(roles
            .Select(x => new GetRoleResponse(x.Id, x.Name, x.Description, x.CreatedAt, x.UpdatedAt, x.IsDeleted))
            .ToList(), cancellation: cancellationToken);
    }
}