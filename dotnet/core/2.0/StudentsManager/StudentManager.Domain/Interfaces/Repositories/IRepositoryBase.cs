using StudentsManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManager.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        Task AddAsync(TEntity obj);

        TEntity GetById(int id);

        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<PaginatedList<TEntity>> GetAllPagedAsync(int? pageSize = 1, int? page = 1);

        IEnumerable<TEntity> GetAll();

        void Update(int id, TEntity obj);

        Task UpdateAsync(int id, TEntity obj);

        Task Remove(int id);

        void Dispose();
    }
}