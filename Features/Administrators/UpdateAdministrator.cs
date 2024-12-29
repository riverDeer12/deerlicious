using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Administrators;

public sealed record UpdateAdministratorRequest(string FirstName, string LastName);
public sealed record UpdateAdministratorResponse(Guid Id, string FullName);

public class UpdateAdministratorEndpoint : Endpoint<UpdateAdministratorRequest, UpdateAdministratorResponse>
{
    private readonly DeerliciousContext _context;

    public UpdateAdministratorEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Put("api/administrators/{id}");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Administrators"));
    }

    public override async Task HandleAsync(UpdateAdministratorRequest req, CancellationToken ct)
    {
        var administratorId = Route<Guid>("id", isRequired: true);

        var administrator =
            await _context.Administrators
                .FirstOrDefaultAsync(x => x.Id == administratorId, cancellationToken: ct);

        if (administrator is null)
            ThrowError(ErrorMessages.NotFound);

        administrator.FirstName = req.FirstName;
        administrator.LastName = req.LastName;

        _context.Administrators.Update(administrator);

        var result = await _context.SaveChangesAsync(ct);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new(administrator.Id, administrator.FullName), cancellation: ct);
    }
}