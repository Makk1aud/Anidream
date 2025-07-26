using Microsoft.AspNetCore.Mvc;

namespace Anidream.API.Controllers;

[ApiController]
[Route("api/test")]
public class WeatherForecastController : ControllerBase
{
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
    }

    [HttpGet]
    [Route("ping")]
    public IActionResult Get()
    {
        return Ok("pong");
    }
}