namespace PVS.Domain.Interfaces.Services
{
    public interface ICurrentUserService
    {
        string? CurrentUserId { get; }
    }
}
