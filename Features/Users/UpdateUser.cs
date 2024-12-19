using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Users;

public sealed record UpdateUserRequest(string Email);
public sealed record UpdateUserResponse(string Username, string Email);

public sealed class UpdateUserEndpoint : Endpoint<UpdateUserRequest, UpdateUserResponse>
{
    private readonly DeerliciousContext _context;

    public UpdateUserEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Put("api/users/{id}");
        AllowAnonymous();
        Options(x => x.WithTags("Users"));
    }


    public override async Task HandleAsync(UpdateUserRequest request, CancellationToken c)
    {
        var routeUserId = Route<Guid>("id", isRequired: true);

        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == routeUserId, 
            cancellationToken: c);
        
        if(user is null)
            ThrowError(ErrorMessages.NotFound);

        user.Email = request.Email;

        _context.Users.Update(user);

        var result = await _context.SaveChangesAsync(c);
        
        if(result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new(user.Email, user.UserName), cancellation: c);
    }
}