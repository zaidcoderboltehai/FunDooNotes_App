// FunDooNotes_App.BLL/Interfaces/IUserService.cs
using FunDooNotes_App.DAL.Entities;
using System.Threading.Tasks;

namespace FunDooNotes_App.BLL.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterAsync(User user, string password);
        Task<User?> LoginAsync(string username, string password);
    }
}
