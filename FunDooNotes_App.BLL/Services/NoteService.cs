// FunDooNotes_App.BLL/Services/NoteService.cs

using FunDooNotes_App.BLL.Interfaces; // INoteService interface ko implement karne ke liye import kiya gaya hai
using FunDooNotes_App.DAL.Entities; // Note entity ko use karne ke liye import kiya gaya hai
using FunDooNotes_App.DAL.Repositories; // Repository pattern ka use karne ke liye import kiya gaya hai
using System.Collections.Generic; // List type return karne ke liye ye library use hoti hai
using System.Threading.Tasks; // Async methods ko handle karne ke liye ye library zaroori hai

namespace FunDooNotes_App.BLL.Services
{
    // NoteService class jo INoteService ka implementation provide karti hai
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> _noteRepository; // Notes ke liye repository ka reference

        // Constructor jo repository ka instance set karega
        public NoteService(IRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        // Sare notes ko fetch karne ke liye async method
        public async Task<IEnumerable<Note>> GetAllNotesAsync()
        {
            return await _noteRepository.GetAllAsync();
        }

        // Ek specific note ko uski ID ke basis par fetch karne ke liye async method
        public async Task<Note?> GetNoteByIdAsync(int id)
        {
            return await _noteRepository.GetByIdAsync(id);
        }

        // Naya note create karne ke liye async method
        public async Task<Note> CreateNoteAsync(Note note)
        {
            await _noteRepository.AddAsync(note); // Repository me note add karega
            return note; // Newly created note return karega
        }

        // Existing note ko update karne ke liye async method
        public async Task UpdateNoteAsync(Note note)
        {
            await _noteRepository.UpdateAsync(note); // Repository me note update karega
        }

        // Note ko delete karne ke liye async method
        public async Task DeleteNoteAsync(int id)
        {
            await _noteRepository.DeleteAsync(id); // Repository se note delete karega
        }
    }
}
