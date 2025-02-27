// FunDooNotes_App.WebAPI/Controllers/NotesController.cs
using FunDooNotes_App.BLL.Interfaces;
using FunDooNotes_App.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FunDooNotes_App.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notes = await _noteService.GetAllNotesAsync();
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var note = await _noteService.GetNoteByIdAsync(id);
            if (note == null)
                return NotFound();

            return Ok(note);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Note note)
        {
            var createdNote = await _noteService.CreateNoteAsync(note);
            return CreatedAtAction(nameof(GetById), new { id = createdNote.Id }, createdNote);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Note note)
        {
            if (id != note.Id)
                return BadRequest("Note ID mismatch");

            await _noteService.UpdateNoteAsync(note);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _noteService.DeleteNoteAsync(id);
            return NoContent();
        }
    }
}
