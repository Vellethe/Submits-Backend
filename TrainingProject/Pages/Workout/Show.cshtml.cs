using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingProject.Data;

namespace TrainingProject.Pages.Workout
{
    public class ShowModel : PageModel
    {
        public Models.Workout SelectedWorkout { get; set; }

        private readonly AppDbContext context;
        private readonly AccessControl accessControl;
        public ShowModel(AppDbContext context, AccessControl accessControl)
        {
            this.context = context;
            this.accessControl = accessControl;
        }
        public IActionResult OnGet(int id)
        {

            SelectedWorkout = context.Workouts.Include(x=>x.Owner).Include(x=>x.WorkoutExecises).ThenInclude(x=>x.Exercise).FirstOrDefault(x=>x.Id==id);
            if(SelectedWorkout == null)
            {
                return NotFound();
            }

            if (SelectedWorkout.WorkoutExecises.Any())
            {
                SelectedWorkout.WorkoutExecises.OrderBy(x => x.Exercise.MuscleGroup);
            }

            if (accessControl.AllowedToSee(SelectedWorkout.Owner.Id, SelectedWorkout))
            {
                return Page();
            }
            return Forbid();
        }
    }
}
