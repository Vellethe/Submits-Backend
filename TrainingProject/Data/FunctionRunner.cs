using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Runtime.InteropServices;
using WorkoutFuntions;

namespace TrainingProject.Data
{
    public class FunctionRunner
    {
        public static async Task<string> HelloWorld(string name)
        {
            var uri = new Uri("https://workoutfunction.azurewebsites.net/api/HelloWorld?");
            
            var client = new HttpClient();


            var response = await client.GetStringAsync(uri+$"name={name}");
            return response;
        }
    }
}
