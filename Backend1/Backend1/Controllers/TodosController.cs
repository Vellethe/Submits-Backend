using Backend.Data;
using Backend1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace APIWithDatabase.Controllers
{
    [ApiController]
    [Route("")]
    public class NotesController : ControllerBase
    {
        private readonly TodoContext _database;

        public NotesController(TodoContext database)
        {
            _database = database;
        }

        [HttpGet("notes")]
        public async Task<ActionResult<IEnumerable<Note>>> GetNote()
        {
            if (_database.Notes == null)
            {
                return NotFound();
            }
            return await _database.Notes.ToListAsync();
        }

        [HttpPost("notes")]
        public ActionResult<Note> PostNote(Note note)
        {
            if (_database.Notes == null)
            {
                return NotFound();
            }
            _database.Notes.Add(note);
            _database.SaveChanges();

            return Ok();
        }

        [HttpGet("remaining")]
        public ActionResult GetRemaining()
        {
            var remaining = _database.Notes.Count(n => !n.IsDone);
            return Ok(remaining);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNote(int id)
        {
            if (_database.Notes == null)
            {
                return NotFound();
            }
            var note = await _database.Notes.FindAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateNote(int Id, [FromBody] Note note)
        {
            if (Id != note.Id)
            {
                return BadRequest();
            }

            _database.Entry(note).State = EntityState.Modified;
            await _database.SaveChangesAsync();

            return Ok(note);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteNote(int Id)
        {
            var note = await _database.Notes.FindAsync(Id);

            if (note == null)
            {
                return NotFound();
            }

            _database.Notes.Remove(note);
            await _database.SaveChangesAsync();

            return Ok(note);
        }

        [HttpPost("toggle-all")]
        public async Task<ActionResult> ToggleAll()
        {
            var allDone = _database.Notes.All(n => n.IsDone);
            foreach (var note in _database.Notes)
            {
                note.IsDone = !allDone;
            }
            await _database.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("clear-completed")]
        public async Task<ActionResult> ClearCompleted()
        {
            var completedNotes = _database.Notes.Where(n => n.IsDone);
            _database.Notes.RemoveRange(completedNotes);
            await _database.SaveChangesAsync();
            return Ok();
        }
    }
}