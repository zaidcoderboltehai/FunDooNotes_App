// FunDooNotes_App.DAL/Repositories/IRepository.cs

using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunDooNotes_App.DAL.Repositories
{
    // Generic repository interface jo kisi bhi entity ke liye CRUD operations define karta hai
    public interface IRepository<T> where T : class
    {
        // Saari entities ko fetch karne ke liye
        Task<IEnumerable<T>> GetAllAsync();

        // Ek specific entity ko uske ID se fetch karne ke liye
        Task<T?> GetByIdAsync(int id);

        // Nayi entity add karne ke liye
        Task AddAsync(T entity);

        // Existing entity update karne ke liye
        Task UpdateAsync(T entity);

        // Kisi entity ko ID ke basis pe delete karne ke liye
        Task DeleteAsync(int id);
    }
}
