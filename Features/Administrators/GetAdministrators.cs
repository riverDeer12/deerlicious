using Deerlicious.API.Constants;
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
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Administrators"));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var administrators = await _context.Administrators.ToListAsync(cancellationToken: cancellationToken);

        if (administrators.Count is 0)
            await SendAsync([], cancellation: cancellationToken);

        await SendAsync(administrators
            .Select(x => new GetAdministratorsResponse(x.FullName))
            .ToList(), cancellation: cancellationToken);
    }
}