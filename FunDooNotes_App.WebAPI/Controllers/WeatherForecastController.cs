using Microsoft.AspNetCore.Mvc;

namespace FunDooNotes_App.WebAPI.Controllers
{
    // Ye controller weather forecast se related API requests handle karega
    [ApiController]
    [Route("[controller]")] // API ka route set kar raha hai, example: /WeatherForecast
    public class WeatherForecastController : ControllerBase
    {
        // Possible weather summaries ka ek list banaya hai
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger; // Logging ke liye

        // Constructor jo logger ko inject karega
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // Get API (random weather forecast generate karne ke liye)
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index), // Aaj ki date se aage 5 din ka forecast bana raha hai
                TemperatureC = Random.Shared.Next(-20, 55), // Random temperature generate kar raha hai
                Summary = Summaries[Random.Shared.Next(Summaries.Length)] // Random weather summary select kar raha hai
            })
            .ToArray(); // Result ko array me convert kar raha hai
        }
    }
}
