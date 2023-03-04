using DigitalMark.DTO.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMark.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<ProjectController> _logger;

        public ProjectController(ILogger<ProjectController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<ProjectViewModel> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new ProjectViewModel()).ToArray();
        }
    }
}