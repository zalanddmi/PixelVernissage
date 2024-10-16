﻿using PVS.Domain.Interfaces.Entities;

namespace PVS.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(long id);
    }
}
