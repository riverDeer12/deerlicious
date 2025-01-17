using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Roles;

public sealed record UpdateRoleRequest(string RoleName, string Description);

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

        role.Name = request.RoleName;
        role.Description = request.Description;

        _context.Roles.Update(role);

        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result > 0)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new UpdateRoleResponse(role.Id, role.Name, role.Description), cancellation: cancellationToken);
    }
}

public sealed class UpdateRoleValidator : Validator<UpdateRoleRequest>
{
    public UpdateRoleValidator()
    {
        RuleFor(x => x.RoleName).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}