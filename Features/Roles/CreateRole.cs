using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using FastEndpoints;
using FluentValidation;

namespace Deerlicious.API.Features.Roles;

public sealed record CreateRoleRequest(string RoleName);

public sealed record CreateRoleResponse(Guid RoleId, string RoleName);

public sealed class CreateRoleEndpoint(DeerliciousContext context) : Endpoint<CreateRoleRequest, CreateRoleResponse>
{
    public override void Configure()
    {
        Post("api/roles");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Roles"));
    }
    
    public override async Task HandleAsync(CreateRoleRequest request, CancellationToken cancellationToken)
    {
        var newRole = Role.Create(request.RoleName);

        context.Roles.Add(newRole);
        
        var result = await context.SaveChangesAsync(cancellationToken);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new CreateRoleResponse(newRole.Id, newRole.Name),
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
