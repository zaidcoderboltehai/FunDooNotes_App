// FunDooNotes_App.DAL/Entities/Note.cs

using System;

namespace FunDooNotes_App.DAL.Entities
{
    // Note class ek model hai jo ek note ka data store karega
    public class Note
    {
        // Unique ID jo har note ke liye alag hoga (Primary Key)
        public int Id { get; set; }

        // Note ka title store karega
        public string Title { get; set; } = string.Empty;

        // Note ka actual content store karega
        public string Content { get; set; } = string.Empty;

        // Note kab create hua hai, iska timestamp store karega (default UTC time)
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // User ID jo yeh batayega ki yeh note kis user ka hai (Foreign Key)
        public int UserId { get; set; }

        // Navigation property jo related User entity ko refer karegi (relationship establish karega)
        public User? User { get; set; }
    }
}
