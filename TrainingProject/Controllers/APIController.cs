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
        public string testign()
        {
            return "hello world";
        }

        [HttpGet]
        [Authorize("AllowAnonymousApi")]
        public List<string> OnGetPizza(int calories)
        {
            //Time(in minutes) = Calories to burn / Calories burned per minute
            //All values (3, 9, 15) are based on an average person.

            int walkTime = calories / 3;
            int weightTime = calories / 9;
            int runTime = calories / 15;

            string walk = "Walking: " + walkTime + " minutes";
            string weight = "Weight training: " + weightTime + " minutes";
            string run = "Run: " + runTime + " minutes";

            List<string> times = new List<string>();
            times.Add(walk);
            times.Add(weight);
            times.Add(run);

            return times;
        }
    }
}
