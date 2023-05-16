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
    }
}
