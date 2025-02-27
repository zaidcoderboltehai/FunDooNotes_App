// FunDooNotes_App.BLL/Interfaces/INoteService.cs
using FunDooNotes_App.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunDooNotes_App.BLL.Interfaces
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> GetAllNotesAsync();
        Task<Note?> GetNoteByIdAsync(int id);
        Task<Note> CreateNoteAsync(Note note);
        Task UpdateNoteAsync(Note note);
        Task DeleteNoteAsync(int id);
    }
}
