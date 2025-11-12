using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Storage.UploadMediaImage;

internal sealed class UploadMediaImageCommandHandler : IRequestHandler<UploadMediaImageCommand>
{
    private readonly IMediaStorageService _mediaStorageService;
    private readonly IRepositoryManager _repositoryManager;

    public UploadMediaImageCommandHandler(IMediaStorageService mediaStorageService, IRepositoryManager repositoryManager)
    {
        _mediaStorageService = mediaStorageService;
        _repositoryManager = repositoryManager;
    }
    
    public async Task Handle(UploadMediaImageCommand request, CancellationToken cancellationToken)
    {
        var media = await _repositoryManager.MediaRepository.GetMediaByAliasAsync(request.Alias, tracking: true, cancellationToken: cancellationToken);
        if (media == null)
            throw new MediaNotFoundException(request.Alias);
        
        await _mediaStorageService.UploadImageAsync(request.FileStream, request.FileExtension, request.Alias, cancellationToken);
        
        media.HasImage = true;
        await _repositoryManager.SaveChangesAsync(cancellationToken);
    }
}