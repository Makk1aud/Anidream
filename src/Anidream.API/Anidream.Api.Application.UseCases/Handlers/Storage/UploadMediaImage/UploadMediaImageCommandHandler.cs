using Anidream.Api.Application.Core;
using Anidream.Api.Application.Shared.Exceptions;
using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Storage.UploadMediaImage;

internal sealed class UploadMediaImageCommandHandler : IRequestHandler<UploadMediaImageCommand>
{
    private readonly IMediaStorageService _mediaStorageService;
    private readonly IMediaService _mediaService;

    public UploadMediaImageCommandHandler(IMediaStorageService mediaStorageService, IMediaService mediaService)
    {
        _mediaStorageService = mediaStorageService;
        _mediaService = mediaService;
    }
    
    public async Task Handle(UploadMediaImageCommand request, CancellationToken cancellationToken)
    {
        var media = await _mediaService.GetMediaByAliasAsync(request.Alias, cancellationToken: cancellationToken);
        if (media == null)
            throw new MediaNotFoundException(request.Alias);
        
        await _mediaStorageService.UploadImageAsync(request.FileStream, request.FileExtension, request.Alias, cancellationToken);
        
        media.HasImage = true;
        await _mediaService.SaveChangesAsync(cancellationToken);
    }
}