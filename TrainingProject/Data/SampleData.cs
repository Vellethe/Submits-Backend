using TrainingProject.Models;

namespace TrainingProject.Data
{
    public class SampleData
    {
        public static void Create(AppDbContext database)
        {
            // If there are no fake accounts, add some.
            string fakeIssuer = "https://example.com";
            if (!database.Accounts.Any(a => a.OpenIDIssuer == fakeIssuer))
            {
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "1111111111",
                    Name = "Brad"
                });
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "2222222222",
                    Name = "Angelina"
                });
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "3333333333",
                    Name = "Will"
                });
            }
            if (!database.Exercises.Any())
            {
                database.Exercises.Add(new Exercise
                {
                    Description = "armhävning",
                    MuscleGroup = "armar",
                    Name = "armhävning"
                });
                database.Exercises.Add(new Exercise
                {
                    Description = "testing",
                    MuscleGroup = "armar",
                    Name = "testing"
                });
            }

            database.SaveChanges();
        }
    }
}
