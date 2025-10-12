using Anidream.Api.Application.Shared;
using Anidream.Api.Application.Shared.Exceptions;
using Anidream.Api.Application.UseCases.Handlers.Storage.DownloadMediaImage;
using Anidream.Api.Application.UseCases.Handlers.Storage.DownloadMediaVideo;
using Anidream.Api.Application.UseCases.Handlers.Storage.GetMediaEpisodesInfo;
using Anidream.Api.Application.UseCases.Handlers.Storage.UploadMediaImage;
using Anidream.Api.Application.UseCases.Handlers.Storage.UploadMediaVideo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Anidream.API.Controllers;

[ApiController]
[Route("api/[controller]/media")]
public class StorageController : ControllerBase
{
    private readonly ISender _sender;

    public StorageController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpPost("image/{alias}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadImage(
        [FromRoute] string alias,
        IFormFile file,
        CancellationToken cancellationToken)
    {
        if(!ValidateImage(file) || !ValidateFileExtension(file.FileName, Constants.FileStorage.ImageExtension))
            throw new MediaUnsupportedImageType($"The file provided is not a valid file format: {file.ContentType}. Valid format only {Constants.FileStorage.ImageExtension}.");
         
        await _sender.Send(
            new UploadMediaImageCommand(alias, file.OpenReadStream(), Path.GetExtension(file.FileName)),
            cancellationToken);
        return Ok();
    }
    
    [HttpGet("image/{alias}")]
    public async Task<IActionResult> DownloadImage([FromRoute] string alias, CancellationToken cancellationToken)
    {
        var fileStream = await _sender.Send(new DownloadMediaImageQuery(alias), cancellationToken);
        return File(fileStream, Constants.FileStorage.ImageContentType);
    }
    
    [HttpGet("video/{alias}/episode/{episodeNumber}")]
    public async Task<IActionResult> DownloadVideo(
        [FromRoute] string alias,
        [FromRoute] string episodeNumber,
        CancellationToken cancellationToken)
    {
        var stream = await _sender.Send(new DownloadMediaVideoQuery(alias, episodeNumber), cancellationToken);
        return new FileStreamResult(stream, Constants.FileStorage.VideoContentType) {EnableRangeProcessing = true};
    }
    
    [HttpGet("video/{alias}/episodes/info")]
    public async Task<IActionResult> DownloadVideo([FromRoute] string alias, CancellationToken cancellationToken)
    {
        var episodesInfo = await _sender.Send(new GetMediaEpisodesInfoQuery(alias), cancellationToken);
        return Ok(episodesInfo);
    }
    
    [HttpPost("video/{alias}/episode/{episodeNumber}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadVideo(
        [FromRoute] string alias,
        [FromRoute] int episodeNumber,
        IFormFile file,
        CancellationToken cancellationToken)
    {
        //Todo: Валидация на размер файла
        if(!ValidateFileExtension(file.FileName, Constants.FileStorage.VideoExtension))
            return BadRequest($"The file provided is not a valid file extension: {Constants.FileStorage.VideoExtension}.");
        
        await _sender.Send(new UploadMediaVideoCommand(alias, episodeNumber.ToString(), file.OpenReadStream()), cancellationToken);
        return Ok();
    }
    
    //Todo: вынести это
    private bool ValidateImage(IFormFile file) =>
        file.Length > 0 && file.ContentType.Equals(Constants.FileStorage.ImageContentType, StringComparison.CurrentCultureIgnoreCase);
    
    private bool ValidateFileExtension(string fileName, string fileExtension) =>
        fileName.EndsWith(fileExtension);
}