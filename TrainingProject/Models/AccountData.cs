using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Principal;

namespace TrainingProject.Models
{
    public class AccountData
    {
        public int Id { get; set; } 
        public int TargetWeight { get; set; }
        public string Goal { get; set; } = "None";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // public Account User { get; set; }

        public int AccountId { get; set; }  

        public AccountData()
        {
            
        }

        public int DayCount(DateTime curentDate, DateTime targetDate)
        {
            TimeSpan timeSpan = targetDate - curentDate;
            int numberOfDays = timeSpan.Days;

            return numberOfDays;
        }

        public int CalorieCut(Account account, AccountData accountData)
        {
            int curentWeight = account.CurrentWeight;
            int targetWeight = accountData.TargetWeight;
            int caloriesTotal = (curentWeight - targetWeight) * 7700;
            int numberOfDays = caloriesTotal / 600;

            if (accountData.Goal == "Lose")
            {
                return caloriesTotal / numberOfDays;
            }
            else if (accountData.Goal == "Gain")
            {
                return 0;
            }
            else
            {
                return 0;
            }

        }
        public (string FinishedBMR, string FinishedDate) CalorieCalculator(Account account, AccountData accountData)
        {

            double heightInMeters = account.Height / 100.0;
            double bmi = accountData.TargetWeight / (heightInMeters * heightInMeters);

            int calorieCut = this.CalorieCut(account, accountData);

            if (bmi < 19.5)
            {
                return ("0", "");
            }
            else
            {
                //Calculating according to gender


                double bmr = CalculateBMR(account, accountData);
                double finishedBMR = Math.Round(bmr) - calorieCut;
                int caloriesTotal = (account.CurrentWeight - accountData.TargetWeight) * 7700;
                int numberOfDays = caloriesTotal / 600;
                DateTime finishedDate = DateTime.Now.AddDays(numberOfDays);

                return (finishedBMR.ToString(), finishedDate.ToString("yyyy/MM/dd"));
            }
        }


        public string[] GetXAxisValues(string start, string end)
        {
            DateTime startDate = DateTime.Parse(start);
            DateTime endDate = DateTime.Parse(end);

            TimeSpan interval = endDate - startDate;

            int days = interval.Days / 10;

            string[] dates = new string[10];
            for (int i = 1; i < 10; i++)
            {
                DateTime date = startDate.AddDays(i * days);
                dates[i - 1] = date.ToString("yyyy-MM-dd");
            }

            return dates;
        }

        public double CalculateBMR(Account account, AccountData accountData)
        {
            if (account.IsMale)
            {
                return ((10 * account.CurrentWeight) + (6.25 * account.Height) - (5 * account.Age) + 5) * 1.55;
            }

            else
            {
                return ((10 * account.CurrentWeight) + (6.25 * account.Height) - (5 * account.Age) - 161) * 1.55;
            }
        }

        public double[] GetProgressData(string[] xValues, Account user)
        {
            double[] progress = new double[xValues.Length];

            

            for (int i = 0; i < xValues.Length; i++)
            {
                DateTime date = DateTime.Parse(xValues[i]);

                if (date >= this.StartDate && date <= this.EndDate)
                {
                    double progressPercentage = (date - this.StartDate).TotalDays / (this.EndDate - this.StartDate).TotalDays;

                    double targetWeight;
                    double currentWeight = user.CurrentWeight;

                    if (this.Goal == "Lose")
                    {
                        targetWeight = this.TargetWeight - (user.CurrentWeight - this.TargetWeight);
                    }
                    else if (this.Goal == "Gain")
                    {
                        targetWeight = this.TargetWeight + (this.TargetWeight - user.CurrentWeight);
                    }

                    else
                    {
                        targetWeight = this.TargetWeight + (this.TargetWeight - user.CurrentWeight);
                    }

                    double weightDiff = targetWeight - user.CurrentWeight;

                    double totalDays = (this.EndDate - this.StartDate).TotalDays;
                    double remainingDays = (this.EndDate - date).TotalDays;
                    double dailyWeightLoss = weightDiff / remainingDays;

                    double projectedWeight = currentWeight + (dailyWeightLoss * (totalDays - remainingDays));

                    progress[i] = Math.Max(0, Math.Min(1, (currentWeight - projectedWeight) / weightDiff));
                }
            }

            return progress;
        }



    }
}

