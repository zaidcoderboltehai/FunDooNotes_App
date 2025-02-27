// FunDooNotes_App.DAL/Entities/User.cs
namespace FunDooNotes_App.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        // Agar zarurat ho to Notes collection bhi add kar sakte hain
        // public ICollection<Note> Notes { get; set; }
    }
}
