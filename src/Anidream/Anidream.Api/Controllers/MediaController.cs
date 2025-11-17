using Anidream.Application.Contracts;
using Anidream.Application.Contracts.Media;
using Anidream.Application.UseCases.Handlers.Media.AddMedia;
using Anidream.Application.UseCases.Handlers.Media.DeleteMedia;
using Anidream.Application.UseCases.Handlers.Media.GetListOfMedia;
using Anidream.Application.UseCases.Handlers.Media.GetMediaById;
using Anidream.Application.UseCases.Handlers.Media.SetDeleteMediaStatus;
using Anidream.Application.UseCases.Handlers.Media.UpdateMedia;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Anidream.Api.Controllers;

//Todo: Добавить на все остальные сущности контроллер, просто с работой через Query от Mediatr без репозиториев
[Route("api/[controller]")]
[ApiController]
public class MediaController : ControllerBase
{
    private readonly ISender _sender;

    public MediaController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("ping")]
    public IActionResult Ping()
    {
        Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
        return Ok(AppDomain.CurrentDomain.BaseDirectory);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetMedias(
        [FromQuery] PaginationOptions paginationOptions,
        [FromQuery] MediaFilter? filter = null,
        CancellationToken cancellationToken = default)
    {
        var pagedMedias = await _sender.Send(
            new GetListOfMediaQuery { PaginationOptions = paginationOptions, Filter = filter}, cancellationToken);
        Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(pagedMedias.Metadata));
        
        return Ok(pagedMedias.Medias);
    }

    [HttpGet("{mediaId}")]
    public async Task<IActionResult> GetMediaById([FromRoute] Guid mediaId, CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new GetMediaByIdQuery { MediaId = mediaId }, cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> PostMedia([FromBody] MediaForCreationRequest mediaRequest, CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new AddMediaCommand() {Request = mediaRequest}, cancellationToken));
    }
    
    [HttpPut("{mediaId}")]
    public async Task<IActionResult> UpdateMedia([FromRoute]Guid mediaId, [FromBody] MediaForUpdateRequest mediaRequest)
    {
        return Ok(await _sender.Send(new UpdateMediaCommand() {MediaId = mediaId, Request = mediaRequest}));
    }
    
    [HttpDelete("status/{mediaId}")]
    public async Task<IActionResult> SetDeleteMediaStatus([FromRoute]Guid mediaId)
    {
        await _sender.Send(new SetDeleteMediaStatusCommand(mediaId));
        return NoContent();
    }
    
    [HttpDelete("{mediaId}")]
    public async Task<IActionResult> DeleteMedia([FromRoute]Guid mediaId)
    {
        await _sender.Send(new DeleteMediaCommand(mediaId));
        return NoContent();
    }
}