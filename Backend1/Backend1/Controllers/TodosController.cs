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
        public ActionResult<IEnumerable<Note>> GetNotes(bool? completed)
        {
            IQueryable<Note> query = _database.Notes;

            if (completed.HasValue)
            {
                query = query.Where(n => n.Completed == !completed.Value);
            }

            var notes = query.ToList();

            return Ok(notes);
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
        public ActionResult<Note> GetNote(int id)
        {
            if (_database.Notes == null)
            {
                return NotFound();
            }
            var note = _database.Notes.Find(id);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteNote(int id)
        {
            var note = _database.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }

            _database.Notes.Remove(note);
            _database.SaveChanges();

            return NoContent();
        }

        [HttpPost("toggle-all")]
        public ActionResult ToggleAllNotes()
        {
            var allNotes = _database.Notes.ToList();
            bool toggleToCompleted = allNotes.All(n => n.Completed);

            foreach (var note in allNotes)
            {
                note.Completed = !toggleToCompleted;
                _database.Entry(note).State = EntityState.Modified;
            }

            _database.SaveChanges();

            return NoContent();
        }


        [HttpPost("clear-completed")]
        public ActionResult ClearCompletedNotes()
        {
            var completedNotes = _database.Notes.Where(n => n.Completed).ToList();
            _database.Notes.RemoveRange(completedNotes);
            _database.SaveChanges();

            return NoContent();
        }

        [HttpGet("{completed}")]
        public IActionResult GetCompletedNotes(bool? completed)
        {
            IQueryable<Note> query = _database.Notes;

            if (completed.HasValue)
            {
                query = query.Where(n => n.Completed == completed.Value);
            }

            var notes = query.ToList();

            return Ok(notes);
        }
    }
}