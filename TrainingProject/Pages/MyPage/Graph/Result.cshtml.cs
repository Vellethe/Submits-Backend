using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainingProject.Data;
using TrainingProject.Models;

namespace TrainingProject.Pages.MyPage.Result
{
    public class IndexModel : PageModel
    {
        public int LoggedInId { get; set; }
        public Account Account { get; set; }
        public Account User { get; set; }
        public AccountData AccountData { get; set; }
        public AccountData UserData { get; set; }
        public (string FinishedBMR, string FinishedDate) CalorieCount { get; set; }
        public decimal WeightDifference { get; set; }
        public (string TargetBMI, string CurrentBMI) BMI { get; set; }

        public (double x, double y)[] Coordinates { get; set; }
        public (double xCoordinate, double yCoordinate) CurrentCoordinate { get; set; }
        public string[] XValues { get; set; }
        public double[] WeightPerDataPoint { get; set; }

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
            XValues = UserData.GetXAxisValues(UserData);
            Coordinates = UserData.GetCoordinates(User, UserData);
            WeightPerDataPoint = UserData.GetWeightPerCoordinate(User, UserData);
            decimal weightLeft = (decimal)UserData.WeightDifference(User, UserData, true);
            CalorieCount = UserData.CalorieCalculator(User, UserData, UserData.Goal, UserData.TargetWeight);
            WeightDifference = Math.Round(weightLeft);
            BMI = ((UserData.BMICalculator(User, UserData, false).ToString("0.00")), (UserData.BMICalculator(User, UserData, true).ToString("0.00")));
            //BMI = (UserData.ConvertToDecimal(UserData.BMICalculator(User, UserData, false)), UserData.ConvertToDecimal(UserData.BMICalculator(User, UserData, true)));
        }

        public IActionResult OnPost()
        {

            CalorieCount = AccountData.CalorieCalculator(User, UserData, UserData.Goal, UserData.TargetWeight);

            return Page();
        }
    }
}
