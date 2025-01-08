using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Administrators;

public sealed record DeleteAdministratorResponse(Guid Id, string FullName);

public sealed class DeleteAdministratorEndpoint(DeerliciousContext context)
    : EndpointWithoutRequest<DeleteAdministratorResponse>
{
    public override void Configure()
    {
        Delete("api/administrators/{id}");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Administrators"));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var administratorId = Route<Guid>("id", isRequired: true);

        var administrator =
            await context.Administrators
                .FirstOrDefaultAsync(x => x.Id == administratorId, cancellationToken: cancellationToken);

        if (administrator is null)
            ThrowError(ErrorMessages.NotFound);

        administrator.Delete();

        context.Administrators.Update(administrator);

        var result = await context.SaveChangesAsync(cancellationToken);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new DeleteAdministratorResponse(administrator.Id, administrator.FullName), cancellation: cancellationToken);
    }
}