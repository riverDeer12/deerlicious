using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Contributors;

public sealed record GetContributorResponse(Guid Id, string FullName);

public sealed class GetContributorsEndpoint : EndpointWithoutRequest<List<GetContributorResponse>>
{
    private readonly DeerliciousContext _context;

    public GetContributorsEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get("api/contributors");
        Policies(UserPolicies.CanGetContributors.Name);
        Options(x => x.WithTags("Contributors"));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var contributors = await _context.Contributors.ToListAsync(cancellationToken);

        if (contributors.Count is 0) 
            await SendAsync([], cancellation: cancellationToken);
        
        await SendAsync(contributors.Select(x => 
            new GetContributorResponse(x.Id, x.FullName)).ToList(), cancellation: cancellationToken);
    }
}