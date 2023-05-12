using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TrainingProject.Data;
using TrainingProject.Models;

namespace TrainingProject.Controllers
{
    [ApiController]
    [Route("/api")]
    public class APIController : ControllerBase
    {
        private readonly AppDbContext _database;
        private readonly List<Account> _tempaccounts = new List<Account>();

        public APIController(AppDbContext database)
        {
            _database = database;
        }

        [HttpPost]
        public ActionResult addAccount(Account account)
        {
            _tempaccounts.Add(account);
            return CreatedAtAction(nameof(GetAccount), new { id = account.Id }, account);
        }

        [HttpGet("{id}")]
        public ActionResult GetAccount(int id)
        {
            var account = _tempaccounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpGet("details")]
        public ActionResult GetDetails()
        {
            var account = _database.Accounts.Select(a => new
            {
                a.Height,
                a.CurentWeight,
                a.TargetWeight
            }).ToList();
            return Ok(account);
        }
    }
}
