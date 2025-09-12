using Anidream.Api.Application.Core;
using Anidream.Api.Application.UseCases.Handlers.Media.AddMedia;
using Anidream.Api.Application.UseCases.Handlers.Media.GetListOfMedia;
using Anidream.Api.Application.UseCases.Handlers.Media.UploadMediaPicture;
using Anidream.Api.Application.UseCases.Services.Entities;
using Anidream.Api.Application.Utils.Dtos;
using Anidream.Api.Application.Utils.Exceptions;
using Anidream.Api.Application.Utils.Handlers.Media.DeleteMedia;
using Anidream.Api.Application.Utils.Handlers.Media.GetMediaById;
using Anidream.Api.Application.Utils.Handlers.Media.UpdateMedia;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Anidream.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MediaController : ControllerBase
{
    private readonly ISender _sender;

    public MediaController(IDbContext context, ISender sender)
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
        [FromBody] MediaFilter? filter = null, //Todo: надо посмотреть на то надо ли использовать в GET body, скорее всего надо будет перенести в url параметры
        CancellationToken cancellationToken = default)
    {
        var medias = await _sender.Send(
            new GetListOfMediaCommand { PaginationOptions = paginationOptions, Filter = filter}, cancellationToken);
        Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(medias.GetMetadata()));
        
        return Ok(medias);
    }

    [HttpGet("{mediaId}")]
    public async Task<IActionResult> GetMediaById([FromRoute] Guid mediaId, CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new GetMediaByIdCommand { MediaId = mediaId }, cancellationToken));
    }

    [HttpPost]//Todo: нельзя дублировать alias при добавлении записей
    public async Task<IActionResult> PostMedia([FromBody] MediaForCreationDto mediaDto, CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new AddMediaCommand() {MediaForCreationDto = mediaDto}, cancellationToken));
    }
    
    [HttpPost("image/{mediaId}")]
    public async Task<IActionResult> UploadImage([FromRoute] Guid mediaId, IFormFile file, CancellationToken cancellationToken)
    {
        if(!ValidateFile(file))
            return BadRequest("File is null or invalid file format");
        
        await _sender.Send(new UploadMediaPictureCommand() { MediaId = mediaId, FileStream = file.OpenReadStream() }, cancellationToken);
        return Ok();
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

    private bool ValidateFile(IFormFile file) =>
        file.Length > 0 && file.ContentType.StartsWith("image/");
}