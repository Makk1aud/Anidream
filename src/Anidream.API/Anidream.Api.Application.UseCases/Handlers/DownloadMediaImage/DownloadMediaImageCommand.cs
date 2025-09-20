using MediatR;

namespace Anidream.Api.Application.Utils.Handlers.DownloadMediaImage;

public class DownloadMediaImageCommand : IRequest<MemoryStream>
{
    public Guid MediaId { get; set; }
}