using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Administrators;

public sealed record DeleteAdministratorResponse(Guid Id, string FullName);

public sealed class DeleteAdministratorEndpoint : EndpointWithoutRequest<DeleteAdministratorResponse>
{
    private readonly DeerliciousContext _context;

    public DeleteAdministratorEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

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
            await _context.Administrators
                .FirstOrDefaultAsync(x => x.Id == administratorId, cancellationToken: cancellationToken);

        if (administrator is null)
            ThrowError(ErrorMessages.NotFound);

        administrator.Delete();

        _context.Administrators.Update(administrator);

        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result == 0)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new DeleteAdministratorResponse(administrator.Id, administrator.FullName), cancellation: cancellationToken);
    }
}