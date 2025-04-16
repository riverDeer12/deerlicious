using Deerlicious.API.Database.Entities;
using Deerlicious.API.Features.Users;

namespace Deerlicious.API.Services;

public interface IUserService
{
    Task<bool> UsernameExists(string username, CancellationToken cancellationToken);
    Task<User> CreateUserAccount(string username, string password, string email,
        CancellationToken cancellationToken);
}