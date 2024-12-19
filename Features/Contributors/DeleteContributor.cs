using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Contributors;

public sealed record DeleteContributorResponse(Guid Id, string FullName);

public class DeleteAdministratorEndpoint : EndpointWithoutRequest<DeleteContributorResponse>
{
    private readonly DeerliciousContext _context;

    public DeleteAdministratorEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Delete("api/contributors/{id}");
        AllowAnonymous();
        Options(x => x.WithTags("Contributors"));
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var contributorId = Route<Guid>("id", isRequired: true);

        var contributor =
            await _context.Contributors
                .FirstOrDefaultAsync(x => x.Id == contributorId, cancellationToken: ct);

        if (contributor is null)
            ThrowError(ErrorMessages.NotFound);

        contributor.Delete();

        _context.Contributors.Update(contributor);

        var result = await _context.SaveChangesAsync(ct);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new DeleteContributorResponse(contributor.Id, contributor.FullName), cancellation: ct);
    }
}