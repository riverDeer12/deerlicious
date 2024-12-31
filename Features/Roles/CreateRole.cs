using Deerlicious.API.Constants;
using FastEndpoints;

namespace Deerlicious.API.Features.Roles;

public sealed record CreateRoleRequest(string RoleName);

public sealed record CreateRoleResponse(Guid RoleId, string RoleName);

public class CreateRoleEndpoint : Endpoint<CreateRoleRequest, CreateRoleResponse>
{
    public override void Configure()
    {
        Post("api/roles");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Roles"));
    }
    
    public override async Task HandleAsync(CreateRoleRequest request, CancellationToken cancellationToken)
    {
        await base.HandleAsync(request, cancellationToken);
    }
}