using Anidream.Api.Application.Shared.Exceptions;
using Anidream.Api.Application.UseCases.Handlers.Media.UploadMediaImage;
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
    
    private bool ValidateFile(IFormFile file) =>
        file.Length > 0 && file.ContentType.StartsWith("image/");
}