using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Policies;

public sealed record AddPolicyToRoleRequest(Guid PolicyId, Guid RoleId);

public sealed record AddPolicyToRoleResponse(Guid PolicyId, Guid RoleId);

public sealed class AddPolicyToRoleEndpoint : Endpoint<AddPolicyToRoleRequest, AddPolicyToRoleResponse>
{
    private readonly DeerliciousContext _context;

    public AddPolicyToRoleEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post("api/policies/add-policy");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Policies"));
    }

    public override async Task HandleAsync(AddPolicyToRoleRequest request, CancellationToken cancellationToken)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == request.RoleId,
            cancellationToken: cancellationToken);

        if (role is null)
            ThrowError(ErrorMessages.NotFound);

        var policy = await _context.Policies.FirstOrDefaultAsync(x => x.Id == request.PolicyId,
            cancellationToken: cancellationToken);

        if (policy is null)
            ThrowError(ErrorMessages.NotFound);

        var rolePolicy = new RolePolicy
        {
            RoleId = request.RoleId,
            PolicyId = request.PolicyId
        };

        _context.RolePolicies.Add(rolePolicy);

        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new AddPolicyToRoleResponse(role.Id, policy.Id),
            cancellation: cancellationToken);
    }
}

public sealed class AddRoleToPolicyValidator : Validator<AddPolicyToRoleRequest>
{
    public AddRoleToPolicyValidator()
    {
        RuleFor(x => x.PolicyId).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.RoleId).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}