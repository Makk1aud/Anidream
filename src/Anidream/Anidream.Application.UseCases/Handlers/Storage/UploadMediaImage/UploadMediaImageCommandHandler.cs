using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Storage.UploadMediaImage;

internal sealed class UploadMediaImageCommandHandler : IRequestHandler<UploadMediaImageCommand>
{
    private readonly IMediaStorageService _mediaStorageService;
    private readonly IMediaRepository _mediaService;

    public UploadMediaImageCommandHandler(IMediaStorageService mediaStorageService, IMediaRepository mediaService)
    {
        _mediaStorageService = mediaStorageService;
        _mediaService = mediaService;
    }
    
    public async Task Handle(UploadMediaImageCommand request, CancellationToken cancellationToken)
    {
        var media = await _mediaService.GetMediaByAliasAsync(request.Alias, tracking: true, cancellationToken: cancellationToken);
        if (media == null)
            throw new MediaNotFoundException(request.Alias);
        
        await _mediaStorageService.UploadImageAsync(request.FileStream, request.FileExtension, request.Alias, cancellationToken);
        
        media.HasImage = true;
        await _mediaService.SaveChangesAsync(cancellationToken);
    }
}