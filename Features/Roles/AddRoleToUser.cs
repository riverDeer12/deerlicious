using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Roles;

public sealed record AddRoleToUserRequest(Guid RoleId, Guid UserId);

public sealed record AddRoleToUserResponse(Guid RoleId, Guid UserId);

public sealed class AddRoleToUserEndpoint : Endpoint<AddRoleToUserRequest, AddRoleToUserResponse>
{
    private readonly DeerliciousContext _context;

    public AddRoleToUserEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post("api/roles/add-user");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Roles"));
    }

    public override async Task HandleAsync(AddRoleToUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

        if (user is null)
            ThrowError(ErrorMessages.NotFound);

        var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == request.RoleId, cancellationToken);

        if (role is null)
            ThrowError(ErrorMessages.NotFound);

        var userRole = new UserRole
        {
            UserId = user.Id,
            RoleId = role.Id
        };

        _context.UserRoles.Add(userRole);
        
        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result > 0)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new AddRoleToUserResponse(role.Id, user.Id),
            cancellation: cancellationToken);
    }
}