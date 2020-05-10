using System;
using System.Threading.Tasks;
using WindowSettings.Entities.Base;

namespace WindowSettings.DataAccess.Base
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        Task<T> GetItemByIdAsync(Int64 id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> RemoveAsync(T entity);
    }
}
