using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainingProject.Data;

namespace TrainingProject.Pages.Workout
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext context;
        public List<Models.Workout> Workouts;
        public IndexModel(AppDbContext context)
        {
            this.context = context;
        }


        public void OnGet()
        {
            Workouts = context.Workouts.ToList();
        }
    }
}
