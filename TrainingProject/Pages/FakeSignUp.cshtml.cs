using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainingProject.Data;
using TrainingProject.Models;

namespace TrainingProject.Pages
{
    public class FakeSignUpModel : PageModel
    {
        private readonly AppDbContext context;
        public FakeSignUpModel(AppDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(string username, string email) 
        {
            string fakeIssuer = "https://example.com";
            context.Accounts.Add(new Account
            {
                OpenIDIssuer = fakeIssuer,
                OpenIDSubject = email,
                Name = username
            });
            context.SaveChanges();

            return RedirectToPage("/FakeLogin");
        }
    }
}
