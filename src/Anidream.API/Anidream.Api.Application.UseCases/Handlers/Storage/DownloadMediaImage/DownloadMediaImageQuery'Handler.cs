using Anidream.Api.Application.Core;
using Anidream.Api.Application.Shared.Exceptions;
using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Storage.DownloadMediaImage;

internal sealed class DownloadMediaImageCommandHandler : IRequestHandler<DownloadMediaQueryCommand, Stream>
{
    private readonly IMediaStorageService _mediaStorageService;
    private readonly IMediaService _mediaService;

    public DownloadMediaImageCommandHandler(IMediaStorageService mediaStorageService, IMediaService mediaService)
    {
        _mediaStorageService = mediaStorageService;
        _mediaService = mediaService;
    }
    
    public async Task<Stream> Handle(DownloadMediaQueryCommand request, CancellationToken cancellationToken)
    {
        var media = await _mediaService.GetMediaByAliasAsync(request.Alias, cancellationToken: cancellationToken);
        
        if (media == null)
            throw new MediaNotFoundException(request.Alias);
        
        return !media.HasImage 
            ? throw new MediaBadRequestException("Media has no image") 
            : await _mediaStorageService.DownloadImageAsync(request.Alias, cancellationToken);
    }
}