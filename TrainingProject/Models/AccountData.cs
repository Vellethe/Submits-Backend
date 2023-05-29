﻿using Microsoft.AspNetCore.Mvc.RazorPages;
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
                dates[i] = date.ToString("yy/MM/dd");
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


        public (double, double)[] GetDataPoints(AccountData userData)
        {
            var dataPoints = new (double xValue, double yValue)[11];

            double[] weightPerDataPoint = GetWeightPerDataPoint(userData);

            double graphHeight = 300;
            double graphBottomPadding = 50;

            for (int i = 0; i < 11; i++)
            {
                double xCoordinate = i * 700 / 10 + 50;
                double yCoordinate = graphHeight - ((weightPerDataPoint[i] - 0) / 20) * 30 + graphBottomPadding;

                dataPoints[i].xValue = xCoordinate;
                dataPoints[i].yValue = yCoordinate;
            }

            return dataPoints;
        }

        public double[] GetWeightPerDataPoint(AccountData userData)
        {
            double[] outputArray = new double[11];

            double startWeight = userData.StartWeight;
            double targetWeight = userData.TargetWeight;
            int totalDayCount = DayCount(userData.StartDate, userData.EndDate);
            double weightDifference = 0;

            if (userData.Goal == "Gain")
            {
                weightDifference = targetWeight - startWeight;
            }

            else if (userData.Goal == "Lose")
            {
                weightDifference = startWeight - targetWeight;
            }

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

        public decimal ConvertToDecimal(double value)
        {
            decimal output = (decimal)value;
            return Math.Round(output);
        }


    }
}

