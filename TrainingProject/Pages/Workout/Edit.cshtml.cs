using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
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
        private readonly AccessControl accessControl;

        public EditModel(AppDbContext context, AccessControl accessControl)
        {
            this.context = context;
            this.accessControl = accessControl;

        }

        private bool LoadWorkout()
        {
            SelectedWorkout = context.Workouts.Include(x => x.Owner).Include(x => x.WorkoutExecises).ThenInclude(x => x.Exercise).Where(x => Id == x.Id).FirstOrDefault();
            return SelectedWorkout != null;
        }


        public IActionResult OnGet(int id)
        {
            Id = id;
            if (id == 0)
            {
                SelectedWorkout = new Models.Workout { Owner = context.Accounts.Find(accessControl.LoggedInAccountID), Id = 0, Name = "test",AccessLevel = AccessLevel.Owner};
                context.Workouts.Add(SelectedWorkout);
                context.SaveChanges();
                //dose not work if user navigates directly to workout/edit/
                return Redirect($"./Edit/{SelectedWorkout.Id}");
            }
            else
            {
                if(LoadWorkout() == false)
                {
                    return NotFound();
                }
                if (!accessControl.AllowedToEdit(SelectedWorkout.Owner.Id))
                {
                    return Forbid();
                }

                Exercises = context.Exercises.Where(x => !SelectedWorkout.WorkoutExecises.Select(y => y.Exercise).Contains(x)).ToList();
            }
            return Page();
        }

        public IActionResult OnPost(int id, int intesnity, int exersieId)
        {
            Id = id;

            if (LoadWorkout() == false)
            {
                return NotFound();
            }

            if (!accessControl.AllowedToEdit(SelectedWorkout.Owner.Id))
            {
                return Forbid();
            }
            SelectedWorkout.WorkoutExecises.Add(new WorkoutExecise
            {
                Workout = SelectedWorkout,
                Intensity = (InetensityLevel)intesnity,
                Exercise = context.Exercises.Find(exersieId)
            });
            context.SaveChanges();


            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id, int exersieId)
        {
            Id = id;

            if (LoadWorkout() == false)
            {
                return NotFound();
            }

            if (!accessControl.AllowedToEdit(SelectedWorkout.Owner.Id))
            {
                return Forbid();
            }
            SelectedWorkout.WorkoutExecises.Remove(context.WorkoutExecises.Find(exersieId));

            context.SaveChanges();
            return RedirectToPage();
        }

        public IActionResult OnPostChange(int id, int intesnity, int workoutExerciseId)
        {

            Id = id;
            if (LoadWorkout() == false)
            {
                return NotFound();
            }

            if (!accessControl.AllowedToEdit(SelectedWorkout.Owner.Id))
            {
                return Forbid();
            }

            SelectedWorkout.WorkoutExecises.First(x => x.Id == workoutExerciseId).Intensity = (InetensityLevel)intesnity;
            context.SaveChanges();
            return RedirectToPage();
        }

        public IActionResult OnPostChangeName(int id, string newName)
        {

            Id = id;

            if (LoadWorkout() == false)
            {
                return NotFound();
            }

            if (!accessControl.AllowedToEdit(SelectedWorkout.Owner.Id))
            {
                return Forbid();
            }
            SelectedWorkout.Name = newName;

            context.SaveChanges();

            return RedirectToPage();
        }

        public IActionResult OnPostChangeAccessLevel(int id, AccessLevel newAccessLevel)
        {
            Id = id;
            if (LoadWorkout() == false)
            {
                return NotFound();
            }

            if (!accessControl.AllowedToEdit(SelectedWorkout.Owner.Id))
            {
                return Forbid();
            }
            SelectedWorkout.AccessLevel = newAccessLevel;



            context.SaveChanges();

            return RedirectToPage();
        }
    }
}
