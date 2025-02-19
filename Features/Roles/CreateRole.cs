using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using Deerlicious.API.Features.Permissions;
using FastEndpoints;
using FluentValidation;

namespace Deerlicious.API.Features.Roles;

public sealed record CreateRoleRequest(
    string Name,
    string Description,
    List<GetPermissionResponse> Permissions);

public sealed record CreateRoleResponse(Guid Id, string Name, string Description);

public sealed class CreateRoleEndpoint : Endpoint<CreateRoleRequest, CreateRoleResponse>
{
    private readonly DeerliciousContext _context;

    public CreateRoleEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post("api/roles");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Roles"));
    }

    public override async Task HandleAsync(CreateRoleRequest request, CancellationToken cancellationToken)
    {
        var newRole = Role.Init(request.Name, request.Description);

        _context.Roles.Add(newRole);

        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result == 0)
            ThrowError(ErrorMessages.SavingError);

        var rolePermissions = request.Permissions.Select(requestPermission => new RolePermission
        {
            RoleId = newRole.Id,
            PermissionId = requestPermission.Id
        }).ToList();

        _context.RolePermissions.AddRange(rolePermissions);
        
        var permissionsResult = await _context.SaveChangesAsync(cancellationToken);

        if (permissionsResult == 0)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new CreateRoleResponse(newRole.Id, newRole.Name, newRole.Description),
            cancellation: cancellationToken);
    }
}

public sealed class CreateRoleValidator : Validator<CreateRoleRequest>
{
    public CreateRoleValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.Permissions).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}