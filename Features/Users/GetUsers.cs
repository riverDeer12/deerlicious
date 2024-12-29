using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Users;

public sealed record GetUsersResponse(Guid Id, string Username, string Email, List<string> Roles);

public sealed class GetUsersEndpoint : EndpointWithoutRequest<List<GetUsersResponse>>
{
    private readonly DeerliciousContext _context;

    public GetUsersEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get("api/users");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Users"));
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var users = await _context.Users
            .Include(userRole => userRole.Roles)
            .ThenInclude(userRole => userRole.Role).ToListAsync(ct);

        if (users.Count is 0)
            await SendAsync([], cancellation: ct);

        await SendAsync(users.Select(x =>
                    new GetUsersResponse(
                        x.Id,
                        x.UserName,
                        x.Email,
                        x.Roles.Select(userRole => userRole.Role.Name).ToList()))
                .ToList(),
            cancellation: ct);
    }
}