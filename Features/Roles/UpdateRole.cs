using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using Deerlicious.API.Features.Permissions;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Roles;

public sealed record UpdateRoleRequest(
    string Name,
    string Description,
    List<Guid> Permissions);

public sealed record UpdateRoleResponse(Guid Id, string FullName, string Description);

public class UpdateRoleEndpoint : Endpoint<UpdateRoleRequest, UpdateRoleResponse>
{
    private readonly DeerliciousContext _context;

    public UpdateRoleEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Put("api/roles/{id}");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Roles"));
    }

    public override async Task HandleAsync(UpdateRoleRequest request, CancellationToken cancellationToken)
    {
        var roleId = Route<Guid>("id", isRequired: true);

        var role =
            await _context.Roles
                .FirstOrDefaultAsync(x => x.Id == roleId, cancellationToken: cancellationToken);

        if (role is null)
            ThrowError(ErrorMessages.NotFound);

        role.Name = request.Name;
        role.Description = request.Description;
        
        role.Permissions = new List<RolePermission>(
            request.Permissions.Select(permissionId => new RolePermission
            {
                RoleId = role.Id,
                PermissionId = permissionId
            }));
        
        await _context.RolePermissions
            .Where(rolePermission => rolePermission.RoleId == role.Id)
            .ExecuteDeleteAsync(cancellationToken);

        _context.Roles.Update(role);

        var result = await _context.SaveChangesAsync(cancellationToken: cancellationToken);

        if (result == 0)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new UpdateRoleResponse(role.Id, role.Name, role.Description), cancellation: cancellationToken);
    }
}

public sealed class UpdateRoleValidator : Validator<UpdateRoleRequest>
{
    public UpdateRoleValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}