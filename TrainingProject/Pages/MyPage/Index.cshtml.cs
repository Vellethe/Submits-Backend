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
            HandleAccountData();
            UserData = context.AccountData.First(c => c.AccountId == LoggedInId);
        }
        public void OnGet()
        {
            
        }

        public IActionResult OnPost(string goal, int targetWeight)
        {   
            if (ModelState.IsValid)
            {
                if (User.Age == 0 || User.CurrentWeight == 0 || User.Height == 0)
                {
                    ErrorMessage = "You must first enter your Age, Weight and Height in order to choose a goal.";
                    return Page();
                }

                else if (goal == "Gain" && targetWeight <= User.CurrentWeight)
                {
                    ErrorMessage = @"You can't enter a weight below your own if you wanna gain weight!";
                    return Page();
                }

                else if (goal == "Lose" && targetWeight >= User.CurrentWeight)
                {
                    ErrorMessage = @"You can't enter a weight above your own if you wanna lose weight!";
                    return Page();
                }


                else
                {
                    foreach (var userData in context.AccountData.ToList())
                    {
                        if (userData.AccountId == LoggedInId)
                        {
                            if (targetWeight == 0 && goal != "Maintain")
                            {
                                userData!.Goal = goal;                       
                            }                           

                            else
                            {                                                                                         
                                if (goal == "Maintain")
                                {
                                    targetWeight = User.CurrentWeight;
                                }
                               
                                userData!.Goal = goal;
                                userData.StartWeight = User.CurrentWeight;                                
                                userData.TargetWeight = targetWeight;
                                userData.StartDate = DateTime.Now;
                                (_, string date) = AccountData.CalorieCalculator(User, UserData!, goal, targetWeight);
                                DateTime endDate = DateTime.Parse(date);                              
                                userData.EndDate = endDate;
                            }                          
                        }
                    }

                }

                context.SaveChanges();
            }

            return Page();
        }

        public void HandleAccountData()
        {
            int userData = context.AccountData.Where(c => c.AccountId == LoggedInId).Count();


            if (UserData == null && userData == 0)
            {
                AccountData newAccountData = new();
                {
                    newAccountData.AccountId = LoggedInId;
                    newAccountData.StartWeight = User.CurrentWeight;
                    newAccountData.TargetWeight = User.CurrentWeight;
                    newAccountData.Goal = "None";
                    newAccountData.StartDate = DateTime.Now;
                    newAccountData.EndDate = DateTime.Now;
                }

                context.AccountData.Add(newAccountData);
                context.SaveChanges();
            }
        }
    }
}

