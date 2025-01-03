using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Policies;

public sealed record RemovePolicyFromRoleRequest(Guid PolicyId, Guid RoleId);

public sealed record RemovePolicyFromRoleResponse(Guid PolicyId, Guid RoleId);

public sealed class RemovePolicyFromRoleEndpoint : Endpoint<RemovePolicyFromRoleRequest, RemovePolicyFromRoleResponse>
{
    private readonly DeerliciousContext _context;

    public RemovePolicyFromRoleEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post("api/policies/remove-policy");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Policies"));
    }

    public override async Task HandleAsync(RemovePolicyFromRoleRequest request, CancellationToken cancellationToken)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == request.RoleId,
            cancellationToken: cancellationToken);

        if (role is null)
            ThrowError(ErrorMessages.NotFound);

        var policy = await _context.Policies.FirstOrDefaultAsync(x => x.Id == request.PolicyId,
            cancellationToken: cancellationToken);

        if (policy is null)
            ThrowError(ErrorMessages.NotFound);

        var rolePolicy =
            await _context.RolePolicies.FirstOrDefaultAsync(x => x.PolicyId == policy.Id && x.RoleId == role.Id, 
                cancellationToken: cancellationToken);
        
        if (rolePolicy is null)
            ThrowError(ErrorMessages.NotFound);

        _context.RolePolicies.Remove(rolePolicy);

        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new RemovePolicyFromRoleResponse(role.Id, policy.Id),
            cancellation: cancellationToken);
    }
}

public sealed class RemovePolicyFromRoleValidator : Validator<RemovePolicyFromRoleRequest>
{
    public RemovePolicyFromRoleValidator()
    {
        RuleFor(x => x.PolicyId).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.RoleId).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}