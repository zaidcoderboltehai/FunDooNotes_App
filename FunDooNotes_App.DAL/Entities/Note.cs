// FunDooNotes_App.DAL/Entities/Note.cs
using System;

namespace FunDooNotes_App.DAL.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Foreign key linking to User
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
