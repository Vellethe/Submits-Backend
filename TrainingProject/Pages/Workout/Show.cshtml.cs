using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingProject.Data;
using TrainingProject.Models;

namespace TrainingProject.Pages.Workout
{
    public class ShowModel : PageModel
    {
        public Models.Workout SelectedWorkout { get; set; }
        public RatingEnum Rating { get; set; }

        private readonly AppDbContext context;
        private readonly AccessControl accessControl;
        public ShowModel(AppDbContext context, AccessControl accessControl)
        {
            this.context = context;
            this.accessControl = accessControl;
        }
        public IActionResult OnGet(int id)
        {

            SelectedWorkout = context.Workouts.Include(x => x.Owner).Include(x=>x.Ratings).ThenInclude(x=> x.RatingAcount).Include(x => x.WorkoutExecises).ThenInclude(x => x.Exercise).FirstOrDefault(x => x.Id == id);
            if (SelectedWorkout == null)
            {
                return NotFound();
            }

            Rating = (SelectedWorkout.Ratings.Where(x => x.RatingAcount.Id == accessControl.LoggedInAccountID).FirstOrDefault() ?? new Rating { ChosenRating = RatingEnum.NoRating }).ChosenRating;

            if (accessControl.AllowedToSee(SelectedWorkout.Owner.Id, SelectedWorkout))
            {
                return Page();
            }
            return Forbid();
        }

        public IActionResult OnPost(int id, RatingEnum ratingEnum)
        {
            SelectedWorkout = context.Workouts.Include(x => x.Owner).Include(x=>x.Ratings).ThenInclude(x=> x.RatingAcount).Include(x => x.WorkoutExecises).ThenInclude(x => x.Exercise).FirstOrDefault(x => x.Id == id);
            if (SelectedWorkout == null)
            {
                return NotFound();
            }

            var ratingRecord = SelectedWorkout.Ratings.FirstOrDefault(x => x.RatingAcount.Id == accessControl.LoggedInAccountID);

            if (ratingRecord == null)
            {
                ratingRecord = new Rating() { 
                    ChosenRating = ratingEnum, 
                    RatingAcount = context.Accounts.Find(accessControl.LoggedInAccountID), 
                    Workout = SelectedWorkout };

                context.Ratings.Add(ratingRecord);
                context.SaveChanges();
            }

            if(ratingEnum == RatingEnum.NoRating)
            {
                context.Ratings.Remove(ratingRecord);
                context.SaveChanges();
            }
            else
            {
                ratingRecord.ChosenRating = ratingEnum;
                context.SaveChanges();
            }


            return RedirectToPage();
        }
    }
}
