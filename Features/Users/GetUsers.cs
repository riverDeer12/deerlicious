using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Users;

public sealed record GetUserResponse(
    Guid Id,
    string Username,
    string Email,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt,
    bool IsDeleted,
    List<UserRoleDto> Roles);

public sealed record UserRoleDto(
    Guid Id,
    string Name);

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
            .ThenInclude(userRole => userRole.Role)
            .ToListAsync(cancellationToken);

        if (users.Count is 0)
        {
            await SendAsync([], cancellation: cancellationToken);
            return;
        }
        
        var response = new List<GetUserResponse>();

        foreach (var user in users)
        {
            var userRoles = user.Roles.Select(x => x.Role).ToList();
            
            var rolesResponse = userRoles
                .Select(x => new UserRoleDto(x.Id, x.Name))
                .ToList();
            
            var usersResponse = new GetUserResponse(
                user.Id,
                user.UserName,
                user.Email,
                user.CreatedAt,
                user.UpdatedAt,
                user.IsDeleted,
                rolesResponse);
            
            response.Add(usersResponse);
        }

        await SendAsync(response, cancellation: cancellationToken);
    }
}