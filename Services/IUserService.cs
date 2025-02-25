namespace Deerlicious.API.Services;

public interface IUserService
{
    Task<bool> UsernameExists(string username, CancellationToken cancellationToken);
}