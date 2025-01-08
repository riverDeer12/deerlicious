using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Administrators;

public sealed record GetAdministratorResponse(string FullName);

public sealed class GetAdministratorsEndpoint(DeerliciousContext context)
    : EndpointWithoutRequest<List<GetAdministratorResponse>>
{
    public override void Configure()
    {
        Get("api/administrators");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Administrators"));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var administrators = await context.Administrators.ToListAsync(cancellationToken: cancellationToken);

        if (administrators.Count is 0)
            await SendAsync([], cancellation: cancellationToken);

        await SendAsync(administrators
            .Select(x => new GetAdministratorResponse(x.FullName))
            .ToList(), cancellation: cancellationToken);
    }
}