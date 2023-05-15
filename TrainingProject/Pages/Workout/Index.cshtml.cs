using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingProject.Data;
using TrainingProject.Models;

namespace TrainingProject.Pages.Workout
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext context;
        private readonly AccessControl accessControl;
        public List<Models.Workout> Workouts;
        public List<Models.Workout> MyWorkouts;
        public IndexModel(AppDbContext context, AccessControl accessControl)
        {
            this.context = context;
            this.accessControl = accessControl;
        }


        public void OnGet()
        {
            MyWorkouts = context.Workouts.Include(x => x.Owner).Where(x => x.Owner.Id == accessControl.LoggedInAccountID).ToList();
            Workouts = context.Workouts.Include(x => x.Owner).Where(x => x.AccessLevel == AccessLevel.Everyone && x.Owner.Id != accessControl.LoggedInAccountID).ToList();
        }
    }
}
