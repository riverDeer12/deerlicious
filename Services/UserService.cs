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

    public async Task<User> CreateUserAccount(string username, string password, string email,
        CancellationToken cancellationToken)
    {
        if (await UsernameExists(username, cancellationToken))
            throw new Exception(ValidationMessages.UsernameAlreadyExists);
        
        var user = User.Init(username, password, email);

        _context.Users.Add(user);

        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result == 0)
            throw new Exception(ErrorMessages.SavingError);

        return user;
    }

    public async Task<bool> UsernameExists(string username, CancellationToken cancellationToken)
    {
        return await _context.Users
            .AnyAsync(x => x.UserName == username, cancellationToken);
    }
}