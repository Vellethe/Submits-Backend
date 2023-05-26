using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using TrainingProject.Data;
using TrainingProject.Models;

namespace TrainingProject.Pages.MyPage
{
    public class IndexModel : PageModel
    {
        public int LoggedInId { get; set; }
        public Account Account { get; set; }
        public Account User { get; set; }
        public AccountData AccountData { get; set; }
        public AccountData? UserData { get; set; } 
        public string ErrorMessage { get; set; } = "";

        private readonly AppDbContext context;

        public IndexModel(AppDbContext context, AccessControl access)
        {
            this.context = context;
            LoggedInId = access.LoggedInAccountID;
            Account = new Account();
            User = context.Accounts.First(u => u.Id == LoggedInId);
            AccountData = new AccountData();
            var userData = context.AccountData.First(c => c.AccountId == LoggedInId);

            if (userData != null)
            {
                UserData = context.AccountData.First(c => c.AccountId == LoggedInId);
            }

            else
            {
                FirstLogon();
            }
            

        }
        public void OnGet()
        {
            
        }

        public IActionResult OnPost(string goal, int targetWeight)
        {
            var userData = context.AccountData.First(c => c.AccountId == LoggedInId);

            if (ModelState.IsValid)
            {
                userData!.Goal = goal;
                userData.StartWeight = User.CurrentWeight;
                userData.TargetWeight = targetWeight;
                userData.StartDate = DateTime.Now.AddDays(1);
                userData.EndDate = DateTime.Now.AddDays(601);

                if (goal == "Gain" && targetWeight <= User.CurrentWeight)
                {
                    ErrorMessage = "You can't enter a weight below your own if you wanna gain weight!";
                    return Page();
                }

                else if (goal == "Lose" && targetWeight >= User.CurrentWeight)
                {
                    ErrorMessage = "You can't enter a weight above your own if you wanna lose weight!";
                    return Page();
                }

                context.SaveChanges();
            }

            return Page();
        }

        public void FirstLogon()
        {

            AccountData newAccountData = new();           
            {
                newAccountData.AccountId = LoggedInId;
                newAccountData.StartWeight = 0;
                newAccountData.TargetWeight = 0;
                newAccountData.Goal = "None";
                newAccountData.StartDate = DateTime.Now;
                newAccountData.EndDate = DateTime.Now;           
            }

            context.AccountData.Add(newAccountData);
            context.SaveChanges();
        }
    }
}

