using Deerlicious.API.Database;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Services;

public class UserService : IUserService
{
    private readonly DeerliciousContext _context;

    public UserService(DeerliciousContext context)
    {
        _context = context;
    }

    public async Task<bool> UsernameExists(string username, CancellationToken cancellationToken)
    {
        return await _context.Users
            .AnyAsync(x => x.UserName == username, cancellationToken);
    }
}