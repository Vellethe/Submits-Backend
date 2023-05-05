using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainingProject.Data;
using TrainingProject.Models;

namespace TrainingProject.Pages.MyPage
{
	public class IndexModel : PageModel
	{
		public int loggedInID { get; set; }
		public (string FinishedBMR, string FinishedDate) calorieCount { get; set; }
		public Account account { get; set; }
		public Account user { get; set; }

		private readonly AppDbContext context;
		public IndexModel(AppDbContext context, AccessControl access)
		{
			this.context = context;
			loggedInID = access.LoggedInAccountID;
			account = new Account();
			user = context.Accounts.First(u => u.Id == loggedInID);
        }
		public void OnGet()
		{
			calorieCount = account.CalorieCalculator(user, "lw");
        }

		public IActionResult OnPost(int age, int height, int weight, bool gender, string goal, int targetWeight)
		{
			var user = context.Accounts.First(u => u.Id == loggedInID);

			user.Age = age;
			user.Height = height;
			user.CurentWeight = weight;
			user.IsMale = gender;
			user.TargetWeight = targetWeight;

			context.SaveChanges();

			calorieCount = account.CalorieCalculator(user, goal);

            return Page();
		}
	}
}
