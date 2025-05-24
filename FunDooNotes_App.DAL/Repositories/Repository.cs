// FunDooNotes_App.DAL/Repositories/Repository.cs

using Microsoft.EntityFrameworkCore;
using FunDooNotes_App.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunDooNotes_App.DAL.Repositories
{
    // Yeh generic repository class hai jo kisi bhi entity ke liye common CRUD operations handle karti hai
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context; // Database access ke liye
        private readonly DbSet<T> _dbSet; // Specific entity ka DbSet

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>(); // DbSet ko initialize karna
        }

        // Saari entities ko database se fetch karne ke liye
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        // Specific entity ko ID ke basis pe fetch karne ke liye
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Nayi entity database me add karne ke liye
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync(); // Changes ko database me save karna
        }

        // Existing entity ko update karne ke liye
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync(); // Changes ko database me save karna
        }

        // ID ke basis pe entity delete karne ke liye
        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync(); // Changes ko database me save karna
            }
        }
    }
}
