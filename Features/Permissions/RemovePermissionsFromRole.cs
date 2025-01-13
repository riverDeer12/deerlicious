using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Permissions;

public sealed record RemovePoliciesFromRoleRequest(List<Guid> PermissionIds);

public sealed record RemovePoliciesFromRoleResponse(Guid PermissionId);

public sealed class
    RemovePoliciesFromRoleEndpoint : Endpoint<RemovePoliciesFromRoleRequest, List<RemovePoliciesFromRoleResponse>>
{
    private readonly DeerliciousContext _context;

    public RemovePoliciesFromRoleEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Delete("api/permissions/{roleId}");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Policies"));
    }

    public override async Task HandleAsync(RemovePoliciesFromRoleRequest request, CancellationToken cancellationToken)
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

        var rolePolicies = _context.RolePolicies
            .Where(x => x.RoleId == roleId && request.PermissionIds.Contains(x.PermissionId)).ToList();

        _context.RolePolicies.RemoveRange(rolePolicies);

        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result != rolePolicies.Count)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(rolePolicies
            .Select(x => new RemovePoliciesFromRoleResponse(x.PermissionId))
            .ToList(), cancellation: cancellationToken);
    }
}

public sealed class RemovePermissionFromRoleValidator : Validator<RemovePoliciesFromRoleRequest>
{
    public RemovePermissionFromRoleValidator()
    {
        RuleFor(x => x.PermissionIds).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}