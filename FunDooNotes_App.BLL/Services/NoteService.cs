// FunDooNotes_App.BLL/Services/NoteService.cs
using FunDooNotes_App.BLL.Interfaces;
using FunDooNotes_App.DAL.Entities;
using FunDooNotes_App.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunDooNotes_App.BLL.Services
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> _noteRepository;

        public NoteService(IRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<IEnumerable<Note>> GetAllNotesAsync()
        {
            return await _noteRepository.GetAllAsync();
        }

        public async Task<Note?> GetNoteByIdAsync(int id)
        {
            return await _noteRepository.GetByIdAsync(id);
        }

        public async Task<Note> CreateNoteAsync(Note note)
        {
            await _noteRepository.AddAsync(note);
            return note;
        }

        public async Task UpdateNoteAsync(Note note)
        {
            await _noteRepository.UpdateAsync(note);
        }

        public async Task DeleteNoteAsync(int id)
        {
            await _noteRepository.DeleteAsync(id);
        }
    }
}
