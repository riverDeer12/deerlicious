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

    public override async Task HandleAsync(CancellationToken ct)
    {
        var contributors = await _context.Contributors.ToListAsync(ct);

        if (contributors.Count is 0) 
            await SendAsync(new List<GetContributorsResponse>(), cancellation: ct);
        
        await SendAsync(new List<GetContributorsResponse>(), cancellation: ct);
    }
}