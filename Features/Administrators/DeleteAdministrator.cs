using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Administrators;

public sealed record DeleteAdministratorResponse(Guid Id, string FullName);

public class DeleteAdministratorEndpoint : EndpointWithoutRequest<DeleteAdministratorResponse>
{
    private readonly DeerliciousContext _context;

    public DeleteAdministratorEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Delete("api/administrators/{id}");
        AllowAnonymous();
        Options(x => x.WithTags("Administrators"));
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var administratorId = Route<Guid>("id", isRequired: true);

        var administrator =
            await _context.Administrators
                .FirstOrDefaultAsync(x => x.Id == administratorId, cancellationToken: ct);

        if (administrator is null)
            ThrowError(ErrorMessages.NotFound);

        administrator.Delete();

        _context.Administrators.Update(administrator);

        var result = await _context.SaveChangesAsync(ct);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new DeleteAdministratorResponse(administrator.Id, administrator.FullName), cancellation: ct);
    }
}