using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using Deerlicious.API.Features.Roles;
using EFCore.BulkExtensions;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Policies;

public sealed record AddPoliciesToRoleRequest(List<Guid> PolicyIds);

public sealed record AddPoliciesToRoleResponse(Guid PolicyId);

public sealed class AddPoliciesToRoleEndpoint : Endpoint<AddPoliciesToRoleRequest, List<AddPoliciesToRoleResponse>>
{
    private readonly DeerliciousContext _context;

    public AddPoliciesToRoleEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post("api/policies/{roleId}");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Policies"));
    }

    public override async Task HandleAsync(AddPoliciesToRoleRequest request, CancellationToken cancellationToken)
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

        var newRolePolicies =
            policies
                .Select(newRolePolicy => new RolePolicy { RoleId = roleId, PolicyId = newRolePolicy.Id })
                .ToList();

        await _context.BulkInsertOrUpdateAsync(newRolePolicies, cancellationToken: cancellationToken);

        await SendAsync(newRolePolicies
            .Select(x => new AddPoliciesToRoleResponse(x.PolicyId))
            .ToList(), cancellation: cancellationToken);
    }
}

public sealed class AddRoleToPolicyValidator : Validator<AddPoliciesToRoleRequest>
{
    public AddRoleToPolicyValidator()
    {
        RuleFor(x => x.PolicyIds).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}