using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainingProject.Data;

namespace TrainingProject.Pages.MyPage
{
    public class IndexModel : PageModel
    {
        public int loggedInID { get; set; }

		private readonly AppDbContext context;
		public IndexModel(AppDbContext context, AccessControl access)
		{
			this.context = context;
			loggedInID = access.LoggedInAccountID;
		}
		public void OnGet()
        {
        }

        public IActionResult OnPut(int age, int height, int weight, bool gender, int targetWeight, DateOnly tagetDate)
        {
            return NotFound();
        }
    }
}
