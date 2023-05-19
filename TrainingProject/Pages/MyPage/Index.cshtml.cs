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
        public AccountData accountData { get; set; }
        public AccountData userData { get; set; }

        private readonly AppDbContext context;
		public IndexModel(AppDbContext context, AccessControl access)
		{
			this.context = context;
			loggedInID = access.LoggedInAccountID;
			account = new Account();
			user = context.Accounts.First(u => u.Id == loggedInID);
            accountData = new AccountData();
        }
		public void OnGet()
		{
			calorieCount = accountData.CalorieCalculator(user, userData);
        }

		public IActionResult OnPost(int age, int height, int weight, bool gender, string goal, int targetWeight, DateTime startDate, DateTime endDate)
		{
			var user = context.Accounts.First(u => u.Id == loggedInID);

            user.Age = age;
			user.Height = height;
            user.CurrentWeight = weight;
			user.IsMale = gender;
            userData.Goal = goal;
            userData.TargetWeight = targetWeight;         
			userData.StartDate = startDate;
			userData.EndDate = endDate;

			calorieCount = accountData.CalorieCalculator(user, userData);

			if(calorieCount.FinishedBMR == "0")
			{
                return Page();
            }
			else
			{
                context.SaveChanges();
            }

            return Page();
		}
	}
}
