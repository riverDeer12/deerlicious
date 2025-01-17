using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using FastEndpoints;
using FluentValidation;

namespace Deerlicious.API.Features.Roles;

public sealed record CreateRoleRequest(string RoleName, string Description);

public sealed record CreateRoleResponse(Guid RoleId, string RoleName, string Description);

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
        var newRole = Role.Init(request.RoleName, request.Description);

        _context.Roles.Add(newRole);
        
        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result == 0)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new CreateRoleResponse(newRole.Id, newRole.Name, newRole.Description),
            cancellation: cancellationToken);
    }
}

public sealed class CreateRoleValidator : Validator<CreateRoleRequest>
{
    public CreateRoleValidator()
    {
        RuleFor(x => x.RoleName).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}
