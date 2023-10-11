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

        public int DayCount(DateTime currentDate, DateTime targetDate)
        {
            TimeSpan timeSpan = targetDate - currentDate;
            int numberOfDays = timeSpan.Days;

            return numberOfDays;
        }


        public double BMICalculator(Account user, AccountData userData, bool currentBMI)
        {
            double weight = userData.TargetWeight;
            if (currentBMI)
            {
                weight = user.CurrentWeight;
            }
            return weight / ((user.Height / 100.0) * (user.Height / 100.0));
        }



        public (string FinishedBMR, string FinishedDate) CalorieCalculator(Account user, AccountData userData, string goal, int targetWeight)
        {

            double bmr = CalculateBMR(user);
            double finishedBMR;
            int caloriesTotal;

            if (goal == "Maintain")
            {
                return (bmr.ToString(), DateTime.Now.AddMonths(6).ToString("yyyy/MM/dd"));
            }          

            double bmi = BMICalculator(user, userData, false);

            if (bmi < 19.5)
            {
                return ("0", "");
            }
            else
            {
                if (goal == "Gain")
                {
                    finishedBMR = Math.Round(bmr) + 500;
                    caloriesTotal = (targetWeight - user.CurrentWeight) * 7700;
                }

                else 
                {
                    finishedBMR = Math.Round(bmr) - 500;
                    caloriesTotal = (user.CurrentWeight - targetWeight) * 7700;
                }
              
                int numberOfDays = caloriesTotal / 500;
                DateTime finishedDate = DateTime.Now.AddDays(numberOfDays);

                int totalAmountOfDays = userData.DayCount(DateTime.Now, finishedDate);
                int daysToAdd = 0;

                while (totalAmountOfDays % 10 != 0)
                {
                    totalAmountOfDays++;
                    daysToAdd++;
                }

                DateTime outputDate = finishedDate.AddDays(daysToAdd);


                return (finishedBMR.ToString(), outputDate.ToString("yyyy-MM-dd"));
            }
        }


        public string[] GetXAxisValues(AccountData userData)
        {   

            int days = DayCount(userData.StartDate, userData.EndDate) / 10;
            string[] dates = new string[11];
            for (int i = 0; i <= 10; i++)
            {
                int extraDay = 0;
                if (i == 10)
                {
                    extraDay++;
                }
                DateTime date = userData.StartDate.AddDays(i * days + extraDay);              
                string outputDate = date.ToString("yyyy-MM-dd");
                string[] formatArray = outputDate.Split("-"); 

                if (formatArray[1].Contains('0'))
                {
                    formatArray[1] = formatArray[1].Replace("0", "");
                }

                if (formatArray[2].Contains('0'))
                {
                    formatArray[2] = formatArray[2].Replace("0", "");
                }

                outputDate = formatArray[2] + "/" + formatArray[1] + " - " + formatArray[0];
                dates[i] = outputDate;
            }

            return dates;
        }

        public double CalculateBMR(Account account)
        {
            // * 1,55
            if (account.IsMale)
            {
                return ((10 * account.CurrentWeight) + (6.25 * account.Height) - (5 * account.Age) + 5)*1.55;
            }

            else
            {
                return ((10 * account.CurrentWeight) + (6.25 * account.Height) - (5 * account.Age) - 161)*1.55;
            }
        }


        public (double, double)[] GetCoordinates(Account user, AccountData userData)
        {
            var coordinates = new (double x, double y)[11];

            double[] weightPerCoordinate = GetWeightPerCoordinate(user, userData);

            for (int i = 0; i <= 10; i++)
            {
                coordinates[i] = GetCoordinate(userData, weightPerCoordinate[i], i);
            }

            return coordinates;
        }

        public double[] GetWeightPerCoordinate(Account user, AccountData userData)
        {
            double[] outputArray = new double[11];
            int totalDayCount = DayCount(userData.StartDate, userData.EndDate);
            double weightDifferencePerDay = WeightDifference(user, userData, false) / totalDayCount;

            double perCoordinate = totalDayCount / 10;

            for (int i = 0; i <= 10; i++)
            {
                double weightPerDay = userData.StartWeight - (i * perCoordinate * weightDifferencePerDay); 

                if (userData.Goal == "Gain")
                {
                    weightPerDay = userData.StartWeight + (i * perCoordinate * weightDifferencePerDay);
                }

                outputArray[i] = weightPerDay;
            }

            return outputArray;
        }

        public double WeightDifference(Account user, AccountData userData, bool currentWeightDifference)
        {
            int eitherStartOrCurrentWeight = userData.StartWeight;
            if (currentWeightDifference)
            {
                eitherStartOrCurrentWeight = user.CurrentWeight;
            }

            double weightDifference = eitherStartOrCurrentWeight - userData.TargetWeight;

            if (userData.Goal == "Gain")
            {
                weightDifference = userData.TargetWeight - eitherStartOrCurrentWeight;
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
            // graphHeight - (weight / numberOfYValues) * yDistancePer20kg + yCoordinateStart = yCoordinate.
            double yCoordinate = 500 - (weight / 20) * 50 + 100;

            if (i > 0)
            {
                // i * graphWidth / xCoordinates.Length + xCoordinateStart = xCoordinate for xLabels/xValues.
                return (i * 1000 / 10 + 100, yCoordinate);
            }                 
            
            else
            {   // daysPassed / (graphWidth / totalNumberOfDays) + xCoordinateStart = Current xCoordinate according to date.
                return (DayCount(userData.StartDate, DateTime.Now) / (1000 / DayCount(userData.StartDate, userData.EndDate)) + 100, yCoordinate);
            }
        }
    }
}