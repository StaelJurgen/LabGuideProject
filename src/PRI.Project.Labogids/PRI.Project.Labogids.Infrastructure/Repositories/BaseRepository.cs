using Microsoft.EntityFrameworkCore;
using PRI.Project.Labogids.Core.Entities;
using PRI.Project.Labogids.Core.Interfaces.Repositories;
using PRI.Project.Labogids.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _applicationDbContext;
        protected readonly DbSet<T> _table;

        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _table = _applicationDbContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _table.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> AddAsync(T entity)
        {
            await _table.AddAsync(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _table.Update(entity);
            return await SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _table.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
        
        private async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
