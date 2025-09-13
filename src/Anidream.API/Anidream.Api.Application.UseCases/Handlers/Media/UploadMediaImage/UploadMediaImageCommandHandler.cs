using Anidream.Api.Application.Core;
using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Media.UploadMediaImage;

internal sealed class UploadMediaImageCommandHandler : IRequestHandler<UploadMediaImageCommand>
{
    private readonly IStorageService _storageService;

    public UploadMediaImageCommandHandler(IStorageService storageService)
    {
        _storageService = storageService;
    }
    
    //Взять Media по id и после выгрузки изображения поменять HasImage на True
    public Task Handle(UploadMediaImageCommand request, CancellationToken cancellationToken)
    {
        var newFileName = Path.ChangeExtension(request.MediaId.ToString(), Path.GetExtension(request.FileName));
        return _storageService.UploadImageAsync(request.FileStream, newFileName, cancellationToken);
    }
}