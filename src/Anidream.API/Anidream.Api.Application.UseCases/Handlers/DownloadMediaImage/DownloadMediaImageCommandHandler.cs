using Anidream.Api.Application.Core;
using Anidream.Api.Application.Shared.Exceptions;
using MediatR;

namespace Anidream.Api.Application.Utils.Handlers.DownloadMediaImage;

public class DownloadMediaImageCommandHandler : IRequestHandler<DownloadMediaImageCommand, MemoryStream>
{
    private readonly IStorageService _storageService;
    private readonly IMediaService _mediaService;

    public DownloadMediaImageCommandHandler(IStorageService storageService, IMediaService mediaService)
    {
        _storageService = storageService;
        _mediaService = mediaService;
    }
    
    public async Task<MemoryStream> Handle(DownloadMediaImageCommand request, CancellationToken cancellationToken)
    {
        var media = await _mediaService.GetMediaAsync(request.MediaId, cancellationToken: cancellationToken);
        if (media == null)
            throw new MediaNotFoundException(request.MediaId.ToString());
        if(!media.HasImage)
            throw new MediaBadRequestException("Media has no image");
        
        return await _storageService.DownloadImageAsync(request.MediaId.ToString(), cancellationToken);
    }
}