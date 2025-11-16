using Anidream.Application.Contracts.Director;
using Anidream.Application.Contracts.Genre;
using Anidream.Application.UseCases.Handlers.Director.AddDirector;
using Anidream.Application.UseCases.Handlers.Director.DeleteDirector;
using Anidream.Application.UseCases.Handlers.Director.GetDirectorById;
using Anidream.Application.UseCases.Handlers.Director.GetDirectors;
using Anidream.Application.UseCases.Handlers.Director.UpdateDirector;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Anidream.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class DirectorController : ControllerBase
{
    private readonly ISender _sender;

    public DirectorController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetListOfDirectors(CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new GetListOfDirectorsQuery(), cancellationToken));
    }
    
    [HttpGet("{directorId}")]
    public async Task<IActionResult> GetDirectorById([FromRoute] Guid directorId, CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new GetDirectorByIdQuery(directorId), cancellationToken));
    }
    
    [HttpPost]
    public async Task<IActionResult> AddDirector(
        [FromBody] DirectorRequest directorRequest,
        CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new AddDirectorCommand(directorRequest), cancellationToken));
    }
    
    [HttpPut("{directorId}")]
    public async Task<IActionResult> AddDirector(
        [FromRoute] Guid directorId,
        [FromBody] DirectorRequest directorRequest,
        CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new UpdateDirectorCommand(directorId, directorRequest), cancellationToken));
    }
    
    [HttpDelete("{directorId}")]
    public async Task<IActionResult> DeleteDirector(
        [FromRoute] Guid directorId,
        CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteDirectorCommand(directorId), cancellationToken);
        return NoContent();
    }
}