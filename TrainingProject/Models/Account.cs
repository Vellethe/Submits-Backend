using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Principal;

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
        public string Goal { get; set; }
        public virtual List<Workout> Workouts { get; set; }
        public int DayCount(DateTime curentDate, DateTime targetDate)
        {
            TimeSpan timeSpan = targetDate - curentDate;
            int numberOfDays = timeSpan.Days;

            return numberOfDays;
        }

        public int CalorieCut(Account account)
        {
            int curentWeight = account.CurentWeight;
            int targetWeight = account.TargetWeight;
            int caloriesTotal = (curentWeight - targetWeight) * 7700;
            int numberOfDays = caloriesTotal / 600;

            if (account.Goal == "Lose Weight")
            {
                return caloriesTotal / numberOfDays;
            }
            else if(account.Goal == "Maintain")
            {
                return 0;
            }
            else
            {

            }
            return 0;
        }
        public (string FinishedBMR, string FinishedDate) CalorieCalculator(Account account)
        {
            double bmr;
            double heightInMeters = account.Height / 100.0;
            double bmi = account.TargetWeight / (heightInMeters * heightInMeters);

            int calorieCut = this.CalorieCut(account);

            if(bmi < 19.5)
            {
                return ("0","");
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

                double finishedBMR = Math.Round(bmr) - calorieCut;
                int caloriesTotal = (account.CurentWeight - account.TargetWeight) * 7700;
                int numberOfDays = caloriesTotal / 600;
                DateTime finishedDate = DateTime.Now.AddDays(numberOfDays);

                return (finishedBMR.ToString(), finishedDate.ToString("yyyy/MM/dd"));
            }
        }
    }
}
