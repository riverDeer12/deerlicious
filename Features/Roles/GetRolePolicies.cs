using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Features.Policies;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Roles;

public sealed record GetRolePolicyResponse(Guid PolicyId, string Name, string Description);

public sealed class GetRolePoliciesEndpoint : EndpointWithoutRequest<List<GetRolePolicyResponse>>
{
    private readonly DeerliciousContext _context;

    public GetRolePoliciesEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get("api/roles/{id}/policies");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Roles"));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var roleId = Route<Guid>("id", isRequired: true);

        var rolePolicies = await _context.RolePolicies
            .Where(x => x.RoleId == roleId)
            .Include(x => x.Role)
            .Include(x => x.Policy)
            .ToListAsync(cancellationToken: cancellationToken);

        if (rolePolicies.Count == 0)
            await SendAsync([], cancellation: cancellationToken);

        await SendAsync(rolePolicies
            .Select(x => new GetRolePolicyResponse(x.PolicyId, x.Policy.Name, x.Policy.Description))
            .ToList(), cancellation: cancellationToken);
    }
}