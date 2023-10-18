using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebra.Models.Interfaces
{
    public interface IRepository<T>
    {
        Task<bool> AddAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(string id);
        Task<T> GetAsync(string id);
        Task<IEnumerable<T>> GetAllAsync(bool forceRefresh = false);
    }
}
