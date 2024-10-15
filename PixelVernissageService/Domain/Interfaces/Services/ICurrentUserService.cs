namespace PVS.Domain.Interfaces.Services
{
    public interface ICurrentUserService
    {
        long? CurrentUserId { get; }
    }
}
