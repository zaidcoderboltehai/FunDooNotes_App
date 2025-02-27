// FunDooNotes_App.DAL/Repositories/UserRepositoryDummy.cs
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunDooNotes_App.DAL.Entities;

namespace FunDooNotes_App.DAL.Repositories
{
    public class UserRepositoryDummy : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public Task AddAsync(User entity)
        {
            entity.Id = _users.Count + 1;
            _users.Add(entity);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return Task.FromResult((IEnumerable<User>)_users);
        }

        public Task<User?> GetByIdAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return Task.FromResult(user);
        }

        public Task UpdateAsync(User entity)
        {
            var user = _users.FirstOrDefault(u => u.Id == entity.Id);
            if (user != null)
            {
                user.Username = entity.Username;
                user.Email = entity.Email;
                user.PasswordHash = entity.PasswordHash;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
            return Task.CompletedTask;
        }

        public Task<User?> GetByUsernameAsync(string username)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            return Task.FromResult(user);
        }
    }
}
