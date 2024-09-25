using LoggerService;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILoggerManager _logger;

        public WeatherForecastController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            try
            {
                throw new Exception("Did not find the value you are looking for.");

                _logger.LogInfo("This is an Info message");
                _logger.LogWarn("This is an Warning message");
                _logger.LogDebug("This is a Debug message");
                _logger.LogError("This is an Error message");

                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error is WeatherForecastController.Get(): {ex}");
                return null;
            }
        }

        [HttpGet]
        [Route("getdate")]
        public IActionResult GetDate()
        {
            return Ok(DateTime.Now);
        }
    }
}
