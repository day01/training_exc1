using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ITaskQueue _taskQueue;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        ITaskQueue taskQueue)
    {
        _logger = logger;
        _taskQueue = taskQueue;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

        _taskQueue.Queue((cancellationToken) =>
        {
            cancellationToken.ThrowIfCancellationRequested();

            Thread.Sleep(TimeSpan.FromSeconds(5));
            _logger.LogInformation("WeatherForecast request positive at {EndOfRequest}", DateTime.Now);
        });

        return result;
    }
}