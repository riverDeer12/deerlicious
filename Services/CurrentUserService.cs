namespace Deerlicious.API.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId
    {
        get
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("sub")?.Value;

            if (userIdClaim is null)
                throw new UnauthorizedAccessException("There is no logged user user provided.");

            return Guid.Parse(userIdClaim);
        }
    }
}