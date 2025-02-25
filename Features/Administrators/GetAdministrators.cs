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
    bool IsDeleted,
    AdminUserDto User);

public sealed record AdminUserDto(Guid Id, string Username, string Email);

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
        var administrators = await _context.Administrators.Include(userType => userType.User)
            .ToListAsync(cancellationToken: cancellationToken);

        if (administrators.Count is 0)
        {
            await SendAsync([], cancellation: cancellationToken);
            return;
        }

        var response = new List<GetAdministratorResponse>();

        foreach (var administrator in administrators)
        {
            var adminUser = administrator.User;

            if (adminUser == null) continue;
            
            var adminUserResponse = new AdminUserDto(adminUser.Id, adminUser.UserName, adminUser.Email);

            var roleResponse = new GetAdministratorResponse(administrator.Id, 
                administrator.FirstName, administrator.LastName,
                administrator.CreatedAt,
                administrator.UpdatedAt,
                administrator.IsDeleted, adminUserResponse);

            response.Add(roleResponse);
        }

        await SendAsync(response, cancellation: cancellationToken);
    }
}