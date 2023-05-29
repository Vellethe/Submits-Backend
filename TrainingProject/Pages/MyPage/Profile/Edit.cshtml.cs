using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainingProject.Data;
using TrainingProject.Models;

namespace TrainingProject.Pages.MyPage.Profile
{
    public class IndexModel : PageModel
    {
        public int LoggedInId { get; set; }
        public Account Account { get; set; }
        public Account User { get; set; }
        public AccountData? AccountData { get; set; }
        public AccountData? UserData { get; set; }

        private readonly AppDbContext context;
        public IndexModel(AppDbContext context, AccessControl access)
        {
            this.context = context;
            LoggedInId = access.LoggedInAccountID;
            Account = new Account();
            User = context.Accounts.First(u => u.Id == LoggedInId);         
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost(int age, int height, int weight, bool gender)
        {
            var user = context.Accounts.First(c => c.Id == LoggedInId);

            if (ModelState.IsValid)
            {
                user.Age = age;
                user.Height = height;
                user.CurrentWeight = weight;
                user.IsMale = gender;

                context.SaveChanges();
            }
            
            return Page();            
        }
    }
}
