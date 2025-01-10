using System.Xml.Linq;
using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Policies;

public sealed record RemovePoliciesFromRoleRequest(List<Guid> PolicyIds);

public sealed record RemovePoliciesFromRoleResponse(Guid PolicyId);

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
        Delete("api/policies/{roleId}");
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

        var policies = _context.Policies
            .Where(x => request.PolicyIds.Contains(x.Id))
            .ToList();

        if (request.PolicyIds.Count != policies.Count)
            ThrowError(ErrorMessages.NotFound);

        var rolePolicies = _context.RolePolicies
            .Where(x => x.RoleId == roleId && request.PolicyIds.Contains(x.PolicyId));

        _context.RolePolicies.RemoveRange(rolePolicies);

        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(rolePolicies
            .Select(x => new RemovePoliciesFromRoleResponse(x.PolicyId))
            .ToList(), cancellation: cancellationToken);
    }
}

public sealed class RemovePolicyFromRoleValidator : Validator<RemovePoliciesFromRoleRequest>
{
    public RemovePolicyFromRoleValidator()
    {
        RuleFor(x => x.PolicyIds).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}