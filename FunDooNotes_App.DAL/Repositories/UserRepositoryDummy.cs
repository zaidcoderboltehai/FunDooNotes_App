using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunDooNotes_App.DAL.Entities;

namespace FunDooNotes_App.DAL.Repositories
{
    // Dummy repository for testing without a database.
    public class UserRepositoryDummy : IUserRepository
    {
        // In-memory list to temporarily store users.
        private readonly List<User> _users = new List<User>();

        // Add a new user.
        public Task AddAsync(User entity)
        {
            entity.Id = _users.Count + 1;
            _users.Add(entity);
            return Task.CompletedTask;
        }

        // Retrieve all users.
        public Task<IEnumerable<User>> GetAllAsync()
        {
            return Task.FromResult((IEnumerable<User>)_users);
        }

        // Find a user by ID.
        public Task<User?> GetByIdAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return Task.FromResult(user);
        }

        // Update user data.
        public Task UpdateAsync(User entity)
        {
            var user = _users.FirstOrDefault(u => u.Id == entity.Id);
            if (user != null)
            {
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.Email = entity.Email;
                user.PasswordHash = entity.PasswordHash;
            }
            return Task.CompletedTask;
        }

        // Delete a user by ID.
        public Task DeleteAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
            return Task.CompletedTask;
        }

        // Find a user by email.
        public Task<User?> GetByEmailAsync(string email)
        {
            var user = _users.FirstOrDefault(u => u.Email == email);
            return Task.FromResult(user);
        }
    }
}
