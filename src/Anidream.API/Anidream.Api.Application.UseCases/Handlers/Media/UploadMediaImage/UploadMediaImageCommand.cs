using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Media.UploadMediaImage;

public class UploadMediaImageCommand : IRequest
{
    public Guid MediaId { get; set; }
    public Stream FileStream { get; set; }
    public string FileName { get; set; }
}