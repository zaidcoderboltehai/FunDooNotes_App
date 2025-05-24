// FunDooNotes_App.BLL/Interfaces/INoteService.cs

using FunDooNotes_App.DAL.Entities; // Note entity ko use karne ke liye import kiya gaya hai
using System.Collections.Generic; // List type return karne ke liye ye library use hoti hai
using System.Threading.Tasks; // Asynchronous methods ke liye ye library zaroori hai

namespace FunDooNotes_App.BLL.Interfaces
{
    // INoteService ek interface hai jo note-related operations ko define karta hai
    public interface INoteService
    {
        // Sare notes ko fetch karne ke liye async method
        Task<IEnumerable<Note>> GetAllNotesAsync();

        // Ek specific note ko uske ID ke basis par fetch karne ke liye async method
        Task<Note?> GetNoteByIdAsync(int id);

        // Naya note create karne ke liye async method
        Task<Note> CreateNoteAsync(Note note);

        // Existing note ko update karne ke liye async method
        Task UpdateNoteAsync(Note note);

        // Note ko delete karne ke liye async method
        Task DeleteNoteAsync(int id);
    }
}
