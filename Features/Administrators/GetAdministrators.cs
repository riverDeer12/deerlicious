using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Administrators;

public sealed record GetAdministratorResponse(
    Guid Id,
    string FirstName,
    string LastName,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt,
    bool IsDeleted);

public sealed class GetAdministratorsEndpoint : EndpointWithoutRequest<List<GetAdministratorResponse>>
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
        {
            await SendAsync([], cancellation: cancellationToken);
            return;
        }

        await SendAsync(administrators
            .Select(x =>
                new GetAdministratorResponse(x.Id, x.FirstName, x.LastName, x.CreatedAt, x.UpdatedAt, x.IsDeleted))
            .ToList(), cancellation: cancellationToken);
    }
}