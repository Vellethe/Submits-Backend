using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TrainingProject.Data;
using TrainingProject.Models;

namespace TrainingProject.Data
{
    public class AccessControl
    {
        public int LoggedInAccountID { get; set; }
        public string LoggedInAccountName { get; set; }

        public AccessControl(AppDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext.User;
            string subject = user.FindFirst(ClaimTypes.NameIdentifier).Value;
            string issuer = user.FindFirst(ClaimTypes.NameIdentifier).Issuer;

            LoggedInAccountID = db.Accounts.Single(p => p.OpenIDIssuer == issuer && p.OpenIDSubject == subject).Id;
            LoggedInAccountName = user.FindFirst(ClaimTypes.Name).Value;
        }

        public bool AllowedToEdit(int accountId)
        {
            if (LoggedInAccountID == accountId)
            {
                return true;
            }
            return false;
        }
        public bool AllowedToSee(int accountId, Workout workout)
        {
            return AllowedToEdit(accountId)||workout.AccessLevel == AccessLevel.Everyone;
        }
    }
}
