// FunDooNotes_App.WebAPI/Controllers/NotesController.cs

using FunDooNotes_App.BLL.Interfaces;
using FunDooNotes_App.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FunDooNotes_App.WebAPI.Controllers
{
    // Ye controller notes se related API requests handle karega
    [ApiController]
    [Route("api/[controller]")] // API ka route set kar raha hai, example: api/notes
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService; // Note service ka reference jo business logic handle karega

        // Constructor jo NoteService ko inject karega
        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        // Get API (saare notes retrieve karne ke liye)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notes = await _noteService.GetAllNotesAsync(); // Saare notes ko fetch kar raha hai
            return Ok(notes); // Notes ko response me bhej raha hai
        }

        // Get API (ek particular note retrieve karne ke liye ID ke basis par)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var note = await _noteService.GetNoteByIdAsync(id); // ID ke basis par note fetch kar raha hai
            if (note == null)
                return NotFound(); // Agar note nahi mila to 404 response dega

            return Ok(note); // Note return kar raha hai
        }

        // Post API (naya note create karne ke liye)
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Note note)
        {
            var createdNote = await _noteService.CreateNoteAsync(note); // Naya note create kar raha hai
            return CreatedAtAction(nameof(GetById), new { id = createdNote.Id }, createdNote); // Response bhej raha hai
        }

        // Put API (existing note update karne ke liye)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Note note)
        {
            if (id != note.Id)
                return BadRequest("Note ID mismatch"); // Agar ID match nahi karti to error dega

            await _noteService.UpdateNoteAsync(note); // Note ko update kar raha hai
            return NoContent(); // Response bhej raha hai bina content ke
        }

        // Delete API (note delete karne ke liye)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _noteService.DeleteNoteAsync(id); // Note ko delete kar raha hai
            return NoContent(); // Response bhej raha hai bina content ke
        }
    }
}
