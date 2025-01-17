using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Users;

public sealed record DeleteUserResponse(Guid Id, string Username);

public class DeleteUserEndpoint : EndpointWithoutRequest<DeleteUserResponse>
{
    private readonly DeerliciousContext _context;

    public DeleteUserEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Delete("api/users/{id}");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Users"));
    }
    
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var userId = Route<Guid>("id", isRequired: true);

        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Id == userId, cancellationToken: cancellationToken);

        if (user == null)
            ThrowError(ErrorMessages.NotFound);
        
        user.Delete();

        _context.Users.Update(user);
        
        var result = await _context.SaveChangesAsync(cancellationToken);
        
        if(result == 0)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new DeleteUserResponse(user.Id, user.UserName), cancellation: cancellationToken);
    }
}