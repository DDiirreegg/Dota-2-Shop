using Dota2_Shop.Models;
using System.Linq.Expressions;

namespace Dota2_Shop.Date.Base
{
    public interface IEntityBaseRepository<T> where T : class,  IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProprties);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
