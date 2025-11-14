using Anidream.Application.Contracts.Studio;
using Anidream.Application.UseCases.Handlers.Studio.AddStudio;
using Anidream.Application.UseCases.Handlers.Studio.DeleteStudio;
using Anidream.Application.UseCases.Handlers.Studio.GetListOfStudio;
using Anidream.Application.UseCases.Handlers.Studio.GetStudioById;
using Anidream.Application.UseCases.Handlers.Studio.UpdateStudio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Anidream.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudioController : ControllerBase
{
    private readonly ISender _sender;

    public StudioController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudios(CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new GetListOfStudiosQuery(), cancellationToken));
    }
    
    [HttpGet("{studioId}")]
    public async Task<IActionResult> GetStudioById([FromRoute] Guid studioId, CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new GetStudioByIdQuery(studioId), cancellationToken));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateStudio([FromBody] StudioRequest studioRequest, CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new AddStudioCommand(studioRequest), cancellationToken));
    }
    
    [HttpPut("{studioId}")]
    public async Task<IActionResult> GetStudios([FromRoute] Guid studioId, [FromBody] StudioRequest studioRequest, CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new UpdateStudioCommand(studioId, studioRequest), cancellationToken));
    }
    
    [HttpDelete("{studioId}")]
    public async Task<IActionResult> GetStudios([FromRoute] Guid studioId, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteStudioCommand(studioId), cancellationToken);
        return NoContent();
    }
}