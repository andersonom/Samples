using System;
using System.Linq;
using System.Collections.Generic;
using StudentManager.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using StudentsManager.Domain.Models;

namespace StudentsManager.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected StudentsManagerContext _context;

        public RepositoryBase(StudentsManagerContext context)
        {
            _context = context;
        }

        public void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }

        public async Task AddAsync(TEntity obj)
        {
            await _context.Set<TEntity>().AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<PaginatedList<TEntity>> GetAllPagedAsync(int? pageSize = 1, int? page = 1)
        {
            return await PaginatedList<TEntity>.CreateAsync(
                           _context.Set<TEntity>()
                           .AsNoTracking()
                           .AsQueryable(),
                            page != null && page > 0 ? (int)page : 1,
                            pageSize != null && pageSize > 0 ? (int)pageSize : 1);
        }

        public void Update(int id, TEntity obj)
        {
            TEntity entity = GetById(id);

            if (entity != null)
                _context.Entry(entity).CurrentValues.SetValues(obj);

            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(int id, TEntity obj)
        {
            TEntity entity = GetById(id);

            if (entity != null)
                _context.Entry(entity).CurrentValues.SetValues(obj);

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            TEntity entity = GetById(id);
            _context.Entry(entity).State = EntityState.Deleted; 
          
            //_context.Set<TEntity>().Remove(entity);
           await _context.SaveChangesAsync();
        }
       
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
