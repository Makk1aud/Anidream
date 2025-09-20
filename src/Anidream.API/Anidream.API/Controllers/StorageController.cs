using System.Net;
using System.Net.Http.Headers;
using Anidream.Api.Application.Shared.Exceptions;
using Anidream.Api.Application.UseCases.Handlers.Media.UploadMediaImage;
using Anidream.Api.Application.Utils.Handlers.DownloadMediaImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Anidream.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StorageController : ControllerBase
{
    private readonly ISender _sender;

    public StorageController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpPost("media/image/{mediaId}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadImage([FromRoute] Guid mediaId, IFormFile file, CancellationToken cancellationToken)
    {
        if(!ValidateFile(file))
            throw new MediaUnsupportedImageType($"The file provided is not a valid file format: {file.ContentType}. Valid format only image/");
         
        await _sender.Send(new UploadMediaImageCommand()
        {
            MediaId = mediaId,
            FileStream = file.OpenReadStream(),
            FileName = file.FileName
        }, cancellationToken);
        return Ok();
    }
    
    [HttpGet("media/image/{mediaId}")]
    public async Task<IActionResult> DownloadImage([FromRoute] Guid mediaId, CancellationToken cancellationToken)
    {
        var fileStream = await _sender.Send(new DownloadMediaImageCommand()
        {
            MediaId = mediaId
        }, cancellationToken);
        
        // var result = new HttpResponseMessage(HttpStatusCode.OK)
        // {
        //     Content = new ByteArrayContent(fileStream.ToArray())
        // };
        //
        // result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        // {
        //     FileName = mediaId.ToString() + ".jpg"
        // };
        // result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        return File(fileStream, "image/jpeg");
    }
    
    private bool ValidateFile(IFormFile file) =>
        file.Length > 0 && file.ContentType.StartsWith("image/");
}