using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TrainingProject.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string OpenIDIssuer { get; set; }
        public string OpenIDSubject { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int CurentWeight {get; set; }
        public bool IsMale { get; set; }
        public int TargetWeight { get; set; }
        public DateTime TargetDate { get; set; }
        public virtual List<Workout> Workouts { get; set; }

        public int CalorieCut(Account account, string goal)
        {
            int cut;
            if (goal == "lw")
            {

            }
            else if(goal == "m")
            {

            }
            else
            {

            }
            return 0;
        }
        public double CalorieCalculator(Account account, string goal)
        {
            double bmr;
            double heightInMeters = account.Height / 100.0;
            double bmi = account.TargetWeight / (heightInMeters * heightInMeters);

            int calorieCut = this.CalorieCut(account, goal);

            if(bmi < 19.5)
            {
                return 0;
            }
            else
            {
                //Calculating according to gender
                if (account.IsMale)
                {
                    bmr = ((10 * account.CurentWeight) + (6.25 * account.Height) - (5 * account.Age) + 5) * 1.55;
                }

                else
                {
                    bmr = ((10 * account.CurentWeight) + (6.25 * account.Height) - (5 * account.Age) - 161) * 1.55;
                }
                return Math.Round(bmr) - calorieCut;
            }
        }
    }
}
