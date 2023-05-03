using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TrainingProject.Data;
using TrainingProject.Models;

namespace TrainingProject.Pages.Workout
{
    public class EditModel : PageModel
    {
        public int Id { get; set; }
        public List<Exercise> Exercises { get; set; } 
        public Models.Workout SelectedWorkout { get; set; }


        private readonly AppDbContext context;
        public EditModel(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult OnGet(int id)
        {
            Id = id;
            if (id == 0)
            {
                SelectedWorkout = new Models.Workout { Owner = context.Accounts.First(), Id = 0, Name = "test" };
                context.Workouts.Add(SelectedWorkout);
                context.SaveChanges();
                return Redirect($"./Edit/{SelectedWorkout.Id}");
            }
            else
            {
                SelectedWorkout = context.Workouts.Include(x=>x.WorkoutExecises).ThenInclude(x=>x.Exercise).Where(x=>Id == x.Id).FirstOrDefault();
                if(SelectedWorkout == null)
                {
                    return NotFound();
                }
                Exercises = context.Exercises.Where(x=>!SelectedWorkout.WorkoutExecises.Select(y=>y.Exercise).Contains(x)).ToList();
            }
            return Page();
        }

        public IActionResult OnPost(int id, int intesnity, int exersieId)
        { 
            Id = id;

            SelectedWorkout = context.Workouts.Include(x => x.WorkoutExecises).ThenInclude(x => x.Exercise).Where(x => Id == x.Id).FirstOrDefault();
            if (SelectedWorkout == null)
            {
                return NotFound();
            }
            SelectedWorkout.WorkoutExecises.Add(new WorkoutExecise
            {
                Workout = SelectedWorkout,
                Intensity = intesnity,
                Exercise = context.Exercises.Find(exersieId)
            });
            context.SaveChanges();


            return Redirect($"./{SelectedWorkout.Id}");
        }
    }
}
