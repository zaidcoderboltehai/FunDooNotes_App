using System.ComponentModel.DataAnnotations;

namespace FunDooNotes_App.WebAPI.Models
{
    public class RegisterRequest
    {
        [Required]
        [StringLength(50)]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "First name can contain only letters.")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Last name can contain only letters.")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$",
            ErrorMessage = "Password must be minimum 6 characters, contain at least one uppercase letter, one lowercase letter, one number and one special character.")]
        public string Password { get; set; } = string.Empty;
    }
}
