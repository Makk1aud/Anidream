using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Storage.DownloadMediaImage;

internal sealed class DownloadMediaImageCommandHandler : IRequestHandler<DownloadMediaImageQuery, Stream>
{
    private readonly IMediaStorageService _mediaStorageService;
    private readonly IMediaRepository _mediaService;

    public DownloadMediaImageCommandHandler(IMediaStorageService mediaStorageService, IMediaRepository mediaService)
    {
        _mediaStorageService = mediaStorageService;
        _mediaService = mediaService;
    }
    
    public async Task<Stream> Handle(DownloadMediaImageQuery request, CancellationToken cancellationToken)
    {
        var media = await _mediaService.GetMediaByAliasAsync(request.Alias, cancellationToken: cancellationToken);
        
        if (media == null)
            throw new MediaNotFoundException(request.Alias);
        
        return !media.HasImage 
            ? throw new MediaBadRequestException("Media has no image") 
            : await _mediaStorageService.DownloadImageAsync(request.Alias, cancellationToken);
    }
}