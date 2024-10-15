using PVS.Domain.Interfaces.Entities;

namespace PVS.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : IEntity;

        Task CommitAsync();

        void Rollback();
    }
}
