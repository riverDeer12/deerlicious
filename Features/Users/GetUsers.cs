using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Users;

public sealed record GetUserResponse(Guid Id, string Username, string Email, List<string> Roles);

public sealed class GetUsersEndpoint : EndpointWithoutRequest<List<GetUserResponse>>
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
    
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var users = await _context.Users
            .Include(userRole => userRole.Roles)
            .ThenInclude(userRole => userRole.Role).ToListAsync(cancellationToken);

        if (users.Count is 0)
            await SendAsync([], cancellation: cancellationToken);

        await SendAsync(users.Select(x =>
                    new GetUserResponse(
                        x.Id,
                        x.UserName,
                        x.Email,
                        x.Roles.Select(userRole => userRole.Role.Name).ToList()))
                .ToList(),
            cancellation: cancellationToken);
    }
}