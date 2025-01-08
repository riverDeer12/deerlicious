using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Policies;

public sealed record GetPolicyResponse(Guid PolicyId, string Name, string Description, string Category);

public sealed class GetPoliciesEndpoint(DeerliciousContext context) : EndpointWithoutRequest<List<GetPolicyResponse>>
{
    public override void Configure()
    {
        Get("api/policies");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Policies"));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var policies = await context.Policies.ToListAsync(cancellationToken: cancellationToken);

        await SendAsync(policies
            .Select(x => new GetPolicyResponse(x.Id, x.Name, x.Description, x.Category))
            .ToList(), cancellation: cancellationToken);
    }
}