using PVS.Domain.Interfaces.Services;
using System.Security.Claims;

namespace PVS.Server.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public long? CurrentUserId { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            bool f = long.TryParse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier), out long result);
            CurrentUserId = f ? result : null;
        }
    }
}
