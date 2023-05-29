using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System.Security.Principal;
using TrainingProject.Migrations;

namespace TrainingProject.Models
{
    public class AccountData
    {
        public int Id { get; set; }
        public int StartWeight { get; set; }
        public int TargetWeight { get; set; }
        public string Goal { get; set; } = "None";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
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

        public int CalorieCut(Account user, AccountData userData)
        {
            int curentWeight = user.CurrentWeight;
            int targetWeight = userData.TargetWeight;
            int caloriesTotal = (curentWeight - targetWeight) * 7700;
            int numberOfDays = caloriesTotal / DayCount(userData.StartDate, userData.EndDate);

            if (userData.Goal == "Lose")
            {
                return caloriesTotal / numberOfDays;
            }
            else if (userData.Goal == "Gain")
            {
                return 0;
            }
            else
            {
                return 0;
            }

        }
        public (string FinishedBMR, string FinishedDate) CalorieCalculator(Account user, AccountData userData)
        {

            double heightInMeters = user.Height / 100.0;
            double bmi = userData.TargetWeight / (heightInMeters * heightInMeters);

            int calorieCut = this.CalorieCut(user, userData);

            if (bmi < 19.5)
            {
                return ("0", "");
            }
            else
            {
                //Calculating according to gender


                double bmr = CalculateBMR(user);
                double finishedBMR = Math.Round(bmr) - calorieCut;
                int caloriesTotal = (user.CurrentWeight - userData.TargetWeight) * 7700;
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

            string[] dates = new string[11];
            for (int i = 0; i <= 10; i++)
            {
                DateTime date = startDate.AddDays(i * days);
                string outputDate = date.ToString("yyyy-MM-dd");
                string[] formatArray = outputDate.Split("-");

                if (formatArray[1].Contains('0'))
                {
                    formatArray[1] = formatArray[1].Replace("0", "");
                }

                outputDate = formatArray[2] + "/" + formatArray[1] + " - " + formatArray[0];
                dates[i] = outputDate;
            }

            return dates;
        }

        public double CalculateBMR(Account account)
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


        public (double, double)[] GetCoordinates(AccountData userData)
        {
            var dataPoints = new (double xValue, double yValue)[11];

            double[] weightPerDataPoint = GetWeightPerDataPoint(userData);

            for (int i = 0; i < 11; i++)
            {
                dataPoints[i] = GetCoordinate(userData, weightPerDataPoint[i], i);
            }

            return dataPoints;
        }

        public double[] GetWeightPerDataPoint(AccountData userData)
        {
            double[] outputArray = new double[11];

            double startWeight = userData.StartWeight;
            double targetWeight = userData.TargetWeight;
            int totalDayCount = DayCount(userData.StartDate, userData.EndDate);
            double weightDifference = WeightDifference(userData);

            double weightDifferencePerDay = weightDifference / totalDayCount;

            double perDataPoint = totalDayCount / 10;

            for (int i = 0; i < 11; i++)
            {
                double weightPerDay = 0;

                if (userData.Goal == "Gain")
                {
                    weightPerDay = startWeight + (i * perDataPoint * weightDifferencePerDay);
                }

                else
                {
                    weightPerDay = startWeight - (i * perDataPoint * weightDifferencePerDay);
                }

                outputArray[i] = weightPerDay;
            }

            return outputArray;
        }

        public double WeightDifference(AccountData userData)
        {
            double weightDifference = 0;

            if (userData.Goal == "Gain")
            {
                weightDifference = userData.TargetWeight - userData.StartWeight;
            }

            else 
            {
                weightDifference = userData.StartWeight - userData.TargetWeight;
            }

            return weightDifference;
        }

        public decimal ConvertToDecimal(double value)
        {
            decimal output = (decimal)value;
            return Math.Round(output);
        }

        public (double, double) GetCoordinate(AccountData userData, double weight, int i)
        {
            (double xCoordinate, double yCoordinate) currentDataPoint;

            int totalDayCount = DayCount(userData.StartDate, userData.EndDate);

            int graphLength = 1000;
            double graphHeight = 500;
            double graphBottomPadding = 100;
            double distanceBetweenEachYLabel = 50;
           
            double datePerPixel = graphLength / totalDayCount;
            int totalDaysIntoProgress = DayCount(userData.StartDate, DateTime.Now);

            if (i > 0)
            {
                currentDataPoint.xCoordinate = i * graphLength / 10 + 100;
            }                 
            
            else
            {
                currentDataPoint.xCoordinate = (totalDaysIntoProgress / datePerPixel) + 100;  
            }

            currentDataPoint.yCoordinate = graphHeight - ((weight - 0) / 20) * distanceBetweenEachYLabel + graphBottomPadding;

            return currentDataPoint;
        }
    }
}


