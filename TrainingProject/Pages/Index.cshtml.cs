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
        public string RandomTip { get; set; }
        public List<Models.Workout> Workouts;
        public List<string> Motivation { get; set; } = new List<string>
        { "Every workout is progress towards a stronger and healthier you. Keep pushing yourself to reach your goals!"
        , "Sweat now, shine later. Remember that every drop of sweat is bringing you closer to your fitness goals."
        , "Don't stop when it hurts, stop when you're done. Stay focused and determined to finish your workout strong."
        , "Your body can stand almost anything. It's your mind you have to convince. Believe in yourself and your ability to push through any challenge."
        , "You are stronger than you think. Trust in your abilities and keep pushing yourself to new heights with every workout."
		, "The only bad workout is the one that didn't happen."
        , "The pain you feel today will be the strength you feel tomorrow."
        , "Don't wait for inspiration, be the inspiration."
        , "Sweat is fat crying."
        , "A one-hour workout is only 4% of your day. No excuses."
        , "The body achieves what the mind believes."
        , "The hardest lift of all is lifting your butt off the couch."
        , "It's not about perfect, it's about effort. And when you bring that effort every single day, that's where transformation happens."
        , "Fitness is not about being better than someone else, it's about being better than you used to be."
        , "You don't have to be great to start, but you have to start to be great."};
        public List<string> Tips { get; set; } = new List<string>
        { "Always start your workouts with a warm-up session to prepare your muscles and joints for exercise. This can include light cardiovascular activities like jogging or jumping jacks, followed by dynamic stretches."
        , "Keep your workouts interesting and prevent plateaus by incorporating a variety of exercises. Mix cardio, strength training, and flexibility exercises to target different muscle groups and improve overall fitness."
        , "Whether you're lifting weights or performing bodyweight exercises, it's crucial to maintain proper form. This not only maximizes the effectiveness of the exercise but also reduces the risk of injury. If you're unsure about proper form, consider working with a qualified trainer."
        , "Pay attention to your body's signals during exercise. If you experience sharp pain or discomfort, it's essential to stop and assess the situation. Pushing through pain can lead to injuries, so know your limits and give your body adequate rest when needed."
        , "Hydration is crucial for overall health and performance during workouts. Drink water before, during, and after your exercise sessions to maintain optimal hydration levels. The exact amount of water needed varies depending on factors like intensity, duration, and individual differences."
        , "Rest and recovery are just as important as exercise. Schedule regular rest days in your workout routine to give your body time to repair and rebuild. Overtraining can lead to fatigue, decreased performance, and increased injury risk, so find a balance between exercise and rest."
        , "Establish achievable fitness goals to keep yourself motivated and track your progress. Make sure your goals are specific, measurable, attainable, relevant, and time-bound (SMART). Celebrate your achievements along the way to maintain motivation."
        , "Quality sleep plays a vital role in exercise recovery and overall well-being. Aim for 7-9 hours of uninterrupted sleep each night to support muscle repair, hormone regulation, and cognitive function."};

        private readonly AppDbContext database;
        private readonly AccessControl accessControl;
        public IndexModel(AppDbContext database, AccessControl accessControl)
        {
            this.database = database;
            this.accessControl = accessControl;
        }

        public void OnGet()
        {
            //Random Motivations
            Random randomMotivatíon = new Random();
            int randomIndex = randomMotivatíon.Next(Motivation.Count);
            RandomMotivation = Motivation[randomIndex];

            //Random Tips
            Random randomTips = new Random();
            int randomTipIndex = randomTips.Next(Tips.Count);
            RandomTip = Tips[randomTipIndex];

            //Random Workouts
            var allWorkouts = database.Workouts.Include(x=>x.Ratings).Include(x => x.Owner).Where(x => x.AccessLevel == AccessLevel.Everyone && x.Owner.Id != accessControl.LoggedInAccountID).ToList();
            Random randomWorkout = new Random();
            var shuffledWorkouts = allWorkouts.OrderBy(x => randomWorkout.Next()).ToList();
            Workouts = shuffledWorkouts.Take(5).Select(x => x).ToList();
        }
    }
}