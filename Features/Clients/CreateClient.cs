using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using Deerlicious.API.Features.Administrators;
using Deerlicious.API.Features.Categories;
using Deerlicious.API.Services;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Clients;

public record CreateClientRequest(
    string Username,
    string Password,
    string FirstName,
    string LastName
);

public record CreateClientResponse(
    Guid Id,
    string FirstName,
    string LastName
);

public class CreateClientEndpoint : Endpoint<CreateClientRequest, CreateClientResponse>
{
    private readonly DeerliciousContext _context;
    public readonly IUserService _userService;

    public CreateClientEndpoint(DeerliciousContext context, IUserService userService)
    {
        _context = context;
        _userService = userService;
    }

    public override void Configure()
    {
        Post("api/clients");
        Permissions(nameof(UserPermissions.CanCreateClient));
        Options(x => x.WithTags("Clients"));
    }

    public override async Task HandleAsync(CreateClientRequest request, CancellationToken cancellationToken)
    {
        var userAccount = await _userService.CreateUserAccount(request, request.Password);

        if (userAccount is null)
            ThrowError(ErrorMessages.NotFound);

        var newClient = new Client
        {
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        _context.Clients.Add(newClient);

        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result == 0)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new CreateClientResponse(newClient.Id, newClient.FirstName, newClient.LastName),
            cancellation: cancellationToken);
    }
}