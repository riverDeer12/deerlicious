using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Contributors;

public sealed record UpdateContributorRequest(string FirstName, string LastName);
public sealed record UpdateContributorResponse(Guid Id, string FullName);

public class UpdateContributorEndpoint : Endpoint<UpdateContributorRequest, UpdateContributorResponse>
{
    private readonly DeerliciousContext _context;

    public UpdateContributorEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Put("api/contributors/{id}");
        AllowAnonymous();
        Options(x => x.WithTags("Contributors"));
    }

    public override async Task HandleAsync(UpdateContributorRequest req, CancellationToken ct)
    {
        var contributorId = Route<Guid>("id", isRequired: true);

        var contributor =
            await _context.Contributors
                .FirstOrDefaultAsync(x => x.Id == contributorId, cancellationToken: ct);

        if (contributor is null)
            ThrowError(ErrorMessages.NotFound);

        contributor.FirstName = req.FirstName;
        contributor.LastName = req.LastName;

        _context.Contributors.Update(contributor);

        var result = await _context.SaveChangesAsync(ct);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new(contributor.Id, contributor.FullName), cancellation: ct);
    }
}