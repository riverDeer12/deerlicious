using Deerlicious.API.Features.Users;

namespace Deerlicious.API.Services;

public interface IUserService
{
    Task<bool> UsernameExists(string username, CancellationToken cancellationToken);
    Task<CreateUserResponse> CreateUserAccount(CreateUserRequest request, CancellationToken cancellationToken);
}