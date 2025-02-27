// FunDooNotes_App.DAL/Repositories/IRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunDooNotes_App.DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
