using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using Deerlicious.API.Features.Users;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Services;

public class UserService : IUserService
{
    private readonly DeerliciousContext _context;

    public UserService(DeerliciousContext context)
    {
        _context = context;
    }

    public async Task<CreateUserResponse> CreateUserAccount(CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        if (await UsernameExists(request.Username, cancellationToken))
            ThrowError(ValidationMessages.UsernameAlreadyExists);

        var user = User.Init(request.Username, request.Password, request.Email);

        _context.Users.Add(user);

        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result == 0)
            ThrowError(ErrorMessages.SavingError);

        return new CreateUserResponse(user.Id, user.UserName);
    }

    public async Task<bool> UsernameExists(string username, CancellationToken cancellationToken)
    {
        return await _context.Users
            .AnyAsync(x => x.UserName == username, cancellationToken);
    }
}