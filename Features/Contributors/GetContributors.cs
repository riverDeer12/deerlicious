using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Contributors;

public sealed record GetContributorsResponse(Guid Id, string FullName);

public sealed class GetContributorsEndpoint : EndpointWithoutRequest<List<GetContributorsResponse>>
{
    private readonly DeerliciousContext _context;

    public GetContributorsEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get("api/contributors");
        AllowAnonymous();
        Options(x => x.WithTags("Contributors"));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var contributors = await _context.Contributors.ToListAsync(cancellationToken);

        if (contributors.Count is 0) 
            await SendAsync([], cancellation: cancellationToken);
        
        await SendAsync(contributors.Select(x => 
            new GetContributorsResponse(x.Id, x.FullName)).ToList(), cancellation: cancellationToken);
    }
}