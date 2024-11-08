using PVS.Domain.Interfaces.Services;
using System.Security.Claims;

namespace PVS.Server.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public string? CurrentUserId { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            CurrentUserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
