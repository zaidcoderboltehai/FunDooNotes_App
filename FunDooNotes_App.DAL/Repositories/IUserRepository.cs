// FunDooNotes_App.DAL/Repositories/IUserRepository.cs
using FunDooNotes_App.DAL.Entities;
using System.Threading.Tasks;

namespace FunDooNotes_App.DAL.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
    }
}
