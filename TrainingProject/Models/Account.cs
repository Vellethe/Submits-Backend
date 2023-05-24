using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace TrainingProject.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string OpenIDIssuer { get; set; }
        public string OpenIDSubject { get; set; }
        public string Name { get; set; }
        public bool IsMale { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int CurrentWeight { get; set; }
        public virtual List<Workout>? Workouts { get; set; }

        public virtual List<AccountData>? AccountData { get; set; }

        // public virtual ICollection<AccountData> AccountData { get; set; }
    }


}

