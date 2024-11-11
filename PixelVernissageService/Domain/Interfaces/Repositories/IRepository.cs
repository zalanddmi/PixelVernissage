using PVS.Domain.Interfaces.Entities;
using System.Linq.Expressions;

namespace PVS.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<IEnumerable<T>> GetAllAsNoTrackingAsync();

        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(long id);

        Task<IEnumerable<T>> FindAsNoTrackingAsync(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    }
}
