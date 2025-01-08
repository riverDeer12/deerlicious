namespace Deerlicious.API.Services;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    public Guid UserId
    {
        get
        {
            var userIdClaim = httpContextAccessor.HttpContext?.User?.FindFirst("sub")?.Value;

            return userIdClaim is null ? Guid.Empty : Guid.Parse(userIdClaim);
        }
    }
}