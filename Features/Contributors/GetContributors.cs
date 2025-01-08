using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Contributors;

public sealed record GetContributorResponse(Guid Id, string FullName);

public sealed class GetContributorsEndpoint(DeerliciousContext context)
    : EndpointWithoutRequest<List<GetContributorResponse>>
{
    public override void Configure()
    {
        Get("api/contributors");
        Policies(nameof(UserPolicies.CanGetContributors));
        Options(x => x.WithTags("Contributors"));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var contributors = await context.Contributors.ToListAsync(cancellationToken);

        if (contributors.Count is 0) 
            await SendAsync([], cancellation: cancellationToken);
        
        await SendAsync(contributors.Select(x => 
            new GetContributorResponse(x.Id, x.FullName)).ToList(), cancellation: cancellationToken);
    }
}