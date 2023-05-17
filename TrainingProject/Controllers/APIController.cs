using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TrainingProject.Data;
using TrainingProject.Models;

namespace TrainingProject.Controllers
{
    [ApiController]
    [Route("/api")]
    public class APIController : ControllerBase
    {
        [HttpGet]
        [Authorize("AllowAnonymousApi")]
        public List<string> OnGetPizza(int calories)
        {
            //Time(in minutes) = Calories to burn / Calories burned per minute
            //All values (3, 9, 15) are based on an average person.

            double walkTime = ((double)calories / 3) / 60;
            double weightTime = ((double)calories / 9) / 60;
            double runTime = ((double)calories / 15) / 60;

            string walk = "Walking: " + Math.Round(walkTime, 1) + " H";
            string weight = "Weight training: " + Math.Round(weightTime, 1) + " H";
            string run = "Run: " + Math.Round(runTime, 1) + " H";

            List<string> times = new List<string>();
            times.Add(walk);
            times.Add(weight);
            times.Add(run);

            return times;
        }
    }
}
