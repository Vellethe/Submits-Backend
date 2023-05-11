using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingProject.Data;
using TrainingProject.Models;

namespace TrainingProject.Pages
{
    public class IndexModel : PageModel
    {
        public string RandomMotivation { get; set; }
        public List<Models.Workout> Workouts;
        public List<string> Motivation { get; set; } = new List<string>
        { "Every workout is progress towards a stronger and healthier you. Keep pushing yourself to reach your goals!"
        , "Sweat now, shine later. Remember that every drop of sweat is bringing you closer to your fitness goals."
        , "Don't stop when it hurts, stop when you're done. Stay focused and determined to finish your workout strong."
        , "Your body can stand almost anything. It's your mind you have to convince. Believe in yourself and your ability to push through any challenge."
        , "You are stronger than you think. Trust in your abilities and keep pushing yourself to new heights with every workout."};

        private readonly AppDbContext database;
        private readonly AccessControl accessControl;
        public IndexModel(AppDbContext database, AccessControl accessControl)
        {
            this.database = database;
            this.accessControl = accessControl;
        }

        public void OnGet()
        {
            Random randomMotivatíon = new Random();
            int randomIndex = randomMotivatíon.Next(Motivation.Count);
            RandomMotivation = Motivation[randomIndex];

            var allWorkouts = database.Workouts.Include(x => x.Owner).Where(x => x.AccessLevel == AccessLevel.Everyone && x.Owner.Id != accessControl.LoggedInAccountID).ToList();

            Random randomWorkout = new Random();
            var shuffledWorkouts = allWorkouts.OrderBy(x => randomWorkout.Next()).ToList();

            Workouts = shuffledWorkouts.Take(5).Select(x => x).ToList();
        }
    }
}