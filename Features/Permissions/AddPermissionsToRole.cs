using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using EFCore.BulkExtensions;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Permissions;

public sealed record AddPermissionsToRoleRequest(List<Guid> PermissionIds);

public sealed record AddPermissionsToRoleResponse(Guid PermissionId);

public sealed class AddPermissionsToRoleEndpoint : Endpoint<AddPermissionsToRoleRequest, List<AddPermissionsToRoleResponse>>
{
    private readonly DeerliciousContext _context;

    public AddPermissionsToRoleEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post("api/permissions/{roleId}");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Permissions"));
    }

    public override async Task HandleAsync(AddPermissionsToRoleRequest request, CancellationToken cancellationToken)
    {
        var roleId = Route<Guid>("roleId", isRequired: true);

        var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == roleId,
            cancellationToken: cancellationToken);

        if (role is null)
            ThrowError(ErrorMessages.NotFound);

        var permissions = _context.Permissions
            .Where(x => request.PermissionIds.Contains(x.Id))
            .ToList();

        if (request.PermissionIds.Count != permissions.Count)
            ThrowError(ErrorMessages.NotFound);

        var newRolePermissions =
            permissions
                .Select(newRolePermission => new RolePermission { RoleId = roleId, PermissionId = newRolePermission.Id })
                .ToList();

        await _context.BulkInsertOrUpdateAsync(newRolePermissions, cancellationToken: cancellationToken);

        await SendAsync(newRolePermissions
            .Select(x => new AddPermissionsToRoleResponse(x.PermissionId))
            .ToList(), cancellation: cancellationToken);
    }
}

public sealed class AddRoleToPermissionValidator : Validator<AddPermissionsToRoleRequest>
{
    public AddRoleToPermissionValidator()
    {
        RuleFor(x => x.PermissionIds).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}