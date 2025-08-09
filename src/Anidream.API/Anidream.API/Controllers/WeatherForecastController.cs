using Anidream.Api.Application.Utils.Interfaces.Data;
using Anidream.Api.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Anidream.API.Controllers;

[ApiController]
[Route("api/test")]
public class WeatherForecastController : ControllerBase
{
    private readonly IDbContext _context;

    public WeatherForecastController(IDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("ping")]
    public async Task<IActionResult> Get()
    {
        _context.Medias.Add(new Media() { Title = "NewTest" });
        await _context.SaveChangesAsync();

        Console.WriteLine(_context.Medias.First().Title);
        return Ok("pong");
    }
}