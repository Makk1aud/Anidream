using Anidream.Api.Application.Core;
using Anidream.Api.Application.Shared.Exceptions;
using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Media.UploadMediaImage;

internal sealed class UploadMediaImageCommandHandler : IRequestHandler<UploadMediaImageCommand>
{
    private readonly IStorageService _storageService;
    private readonly IMediaService _mediaService;

    public UploadMediaImageCommandHandler(IStorageService storageService, IMediaService mediaService)
    {
        _storageService = storageService;
        _mediaService = mediaService;
    }
    
    public async Task Handle(UploadMediaImageCommand request, CancellationToken cancellationToken)
    {
        var media = await _mediaService.GetMediaAsync(request.MediaId, cancellationToken: cancellationToken);
        if (media == null)
            throw new MediaNotFoundException(request.MediaId.ToString());
        
        await _storageService.UploadImageAsync(request.FileStream, request.FileName, request.MediaId.ToString(), cancellationToken);
        
        media.HasImage = true;
        await _mediaService.SaveChangesAsync(cancellationToken);
    }
}