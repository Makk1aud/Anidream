using Anidream.Api.Application.Shared.Entities;
using Anidream.Api.Application.UseCases.Handlers.Media.AddMedia;
using Anidream.Api.Application.UseCases.Handlers.Media.GetListOfMedia;
using Anidream.Api.Application.Utils.Dtos;
using Anidream.Api.Application.Utils.Handlers.Media.DeleteMedia;
using Anidream.Api.Application.Utils.Handlers.Media.GetMediaById;
using Anidream.Api.Application.Utils.Handlers.Media.UpdateMedia;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Anidream.API.Controllers;

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
    public async Task<IActionResult> PostMedia([FromBody] MediaForCreationDto mediaDto, CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new AddMediaCommand() {MediaForCreationDto = mediaDto}, cancellationToken));
    }
    
    [HttpPut("{mediaId}")]
    public async Task<IActionResult> UpdateMedia([FromRoute]Guid mediaId, [FromBody] MediaForUpdateDto mediaDto)
    {
        return Ok(await _sender.Send(new UpdateMediaCommand() {MediaId = mediaId, Dto = mediaDto}));
    }
    
    [HttpDelete("{mediaId}")]
    public async Task<IActionResult> DeleteMedia([FromRoute]Guid mediaId)
    {
        await _sender.Send(new DeleteMediaCommand() { MediaId = mediaId });
        return Ok();
    }
}