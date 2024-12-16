using FastEndpoints;
using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Administrators;

public sealed record CreateAdministratorRequest(string FirstName, string LastName, string Email);
public sealed record CreateAdministratorResponse(Guid Id, string FullName);

public sealed class CreateAdministratorEndpoint : Endpoint<CreateAdministratorRequest, CreateAdministratorResponse>
{
    private readonly DeerliciousContext _context;

    public CreateAdministratorEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post("api/administrators");
        AllowAnonymous();
        Options(x => x.WithTags("Administrator"));
    }

    public override async Task HandleAsync(CreateAdministratorRequest request, CancellationToken ct)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email, ct);

        if (user is null)
            ThrowError(ValidationMessages.NotFound);

        var newAdministrator = Administrator.Create(request.FirstName, request.LastName);

        _context.Administrators.Add(newAdministrator);

        var result = await _context.SaveChangesAsync(ct);

        if (result is not 1)
            ThrowError(ValidationMessages.SavingError);

        await SendAsync(new CreateAdministratorResponse(newAdministrator.Id, newAdministrator.FullName),
            cancellation: ct);
    }
}