using Backend.Data;
using Backend1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly TodoContext _database;

        public NotesController(TodoContext database)
        {
            _database = database;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotes(bool? completed)
        {
            var notes = _database.Notes.AsQueryable();
            if (completed.HasValue)
            {
                notes = notes.Where(n => n.IsDone == completed.Value);
            }
            return await notes.ToListAsync();
        }

        [HttpGet("remaining")]
        public async Task<ActionResult<int>> GetRemaining()
        {
            return await _database.Notes.CountAsync(n => !n.IsDone);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutNote(long id, Note note)
        {
            if (id != note.Id)
            {
                return BadRequest();
            }

            _database.Entry(note).State = EntityState.Modified;

            try
            {
                await _database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_database.Notes.Any(n => n.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Note>> PostNote(Note note)
        {
            _database.Notes.Add(note);
            await _database.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNotes), new { id = note.Id }, note);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(long id)
        {
            var note = await _database.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            _database.Notes.Remove(note);
            await _database.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("toggle-all")]
        public async Task<IActionResult> ToggleAll()
        {
            var allDone = await _database.Notes.AllAsync(n => n.IsDone);
            await _database.Notes.ForEachAsync(n => n.IsDone = !allDone);
            await _database.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("clear-completed")]
        public async Task<IActionResult> ClearCompleted()
        {
            var completedNotes = await _database.Notes.Where(n => n.IsDone).ToListAsync();
            _database.Notes.RemoveRange(completedNotes);
            await _database.SaveChangesAsync();
            return NoContent();
        }

        private bool NoteExists(long id)
        {
            return _database.Notes.Any(e => e.Id == id);
        }
    }
}
