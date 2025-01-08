using Deerlicious.API.Constants;
using Deerlicious.API.Database;  
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Contributors;

public sealed record DeleteContributorResponse(Guid Id, string FullName);

public class DeleteAdministratorEndpoint(DeerliciousContext context) : EndpointWithoutRequest<DeleteContributorResponse>
{
    public override void Configure()
    {
        Delete("api/contributors/{id}");
        Policies(nameof(UserPolicies.CanDeleteContributor));
        Options(x => x.WithTags("Contributors"));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var contributorId = Route<Guid>("id", isRequired: true);

        var contributor =
            await context.Contributors
                .FirstOrDefaultAsync(x => x.Id == contributorId, cancellationToken: cancellationToken);

        if (contributor is null)
            ThrowError(ErrorMessages.NotFound);

        contributor.Delete();

        context.Contributors.Update(contributor);

        var result = await context.SaveChangesAsync(cancellationToken);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new DeleteContributorResponse(contributor.Id, contributor.FullName), cancellation: cancellationToken);
    }
}