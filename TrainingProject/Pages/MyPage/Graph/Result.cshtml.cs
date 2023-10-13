using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainingProject.Data;
using TrainingProject.Models;

namespace TrainingProject.Pages.Graph
{
    public class IndexModel : PageModel
    {
        public int LoggedInId { get; set; }
        public (string FinishedBMR, string FinishedDate) CalorieCount { get; set; }
        public Account Account { get; set; }
        public Account User { get; set; }
        public AccountData AccountData { get; set; }
        public AccountData UserData { get; set; }

        private readonly AppDbContext context;
        public IndexModel(AppDbContext context, AccessControl access)
        {
            this.context = context;
            LoggedInId = access.LoggedInAccountID;
            Account = new Account();
            User = context.Accounts.First(u => u.Id == LoggedInId);
            AccountData = new AccountData();
            UserData = context.AccountData.First(c => c.AccountId == LoggedInId);

        }
        public void OnGet()
        {
                    
                if (UserData!.Goal == "Maintain" && User.CurrentWeight != UserData.TargetWeight)
                {
                    UserData.TargetWeight = User.CurrentWeight;
                }

                context.SaveChanges();
            
            CalorieCount = UserData.CalorieCalculator(User, UserData);
        }

        public IActionResult OnPost(int age, int height, int weight, bool gender, string goal, int targetWeight)
        {

            CalorieCount = AccountData.CalorieCalculator(User, UserData);

            return Page();
        }
    }
}
