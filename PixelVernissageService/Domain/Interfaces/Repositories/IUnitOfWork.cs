using Domain.Interfaces.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : IEntity;

        Task CommitAsync();

        void Rollback();
    }
}
