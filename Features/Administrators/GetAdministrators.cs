using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Administrators;

public sealed record GetAdministratorsResponse(string FullName);

public sealed class GetAdministratorsEndpoint : EndpointWithoutRequest<List<GetAdministratorsResponse>>
{
    private readonly DeerliciousContext _context;

    public GetAdministratorsEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get("api/administrators");
        AllowAnonymous();
        Options(x => x.WithTags("Administrators"));
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var administrators = await _context.Administrators.ToListAsync(cancellationToken: ct);

        if (administrators.Count is 0)
            await SendAsync([], cancellation: ct);

        await SendAsync(administrators
            .Select(x => new GetAdministratorsResponse(x.FullName))
            .ToList(), cancellation: ct);
    }
}