using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WindowSettings.DataAccess.DbContext;
using WindowSettings.Entities.Base;

namespace WindowSettings.DataAccess.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        protected readonly EliseDbContext _context;
        public GenericRepository(EliseDbContext context)
        {
            _context = context;
        }

        public virtual Task<T> GetItemByIdAsync(Int64 id)
        {
            return _context.Set<T>().Where(c => c.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> RemoveAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
