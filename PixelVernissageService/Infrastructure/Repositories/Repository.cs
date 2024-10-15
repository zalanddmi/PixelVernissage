using Microsoft.EntityFrameworkCore;
using PVS.Domain.Interfaces.Entities;
using PVS.Domain.Interfaces.Repositories;
using PVS.Infrastructure.Context;

namespace PVS.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly PvsContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(PvsContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
