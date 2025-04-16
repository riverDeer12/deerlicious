using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Features.Administrators;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Clients;

public record DeleteClientResponse(Guid Id, string FirstName, string LastName);

public class DeleteClientEndpoint : EndpointWithoutRequest<DeleteClientResponse>
{
    private readonly DeerliciousContext _context;

    public DeleteClientEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Delete("api/clients/{id}");
        Permissions(nameof(UserPermissions.CanDeleteClient));
        Options(x => x.WithTags("Clients"));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var clientId = Route<Guid>("id", isRequired: true);

        var client =
            await _context.Clients
                .FirstOrDefaultAsync(x => x.Id == clientId, cancellationToken: cancellationToken);

        if (client is null)
            ThrowError(ErrorMessages.NotFound);

        client.Delete();

        _context.Clients.Update(client);

        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result == 0)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new DeleteClientResponse(client.Id, client.FirstName, client.LastName),
            cancellation: cancellationToken);
    }
}