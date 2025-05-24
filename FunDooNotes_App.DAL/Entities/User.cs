// FunDooNotes_App.DAL/Entities/User.cs
using System.ComponentModel.DataAnnotations;

namespace FunDooNotes_App.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // The hashed password will be stored here.
        public string PasswordHash { get; set; } = string.Empty;

        // Optional: If you wish to link notes to the user, you can uncomment the following:
        // public ICollection<Note> Notes { get; set; }
    }
}
