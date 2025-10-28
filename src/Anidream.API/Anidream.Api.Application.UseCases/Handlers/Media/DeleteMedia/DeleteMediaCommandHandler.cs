using Anidream.Api.Application.Core;
using Anidream.Api.Application.Shared.Exceptions;
using MediatR;

namespace Anidream.Api.Application.Utils.Handlers.Media.DeleteMedia;

internal sealed class DeleteMediaCommandHandler : IRequestHandler<DeleteMediaCommand>
{
    private readonly IMediaService _mediaService;

    public DeleteMediaCommandHandler(IMediaService mediaService)
    {
        _mediaService = mediaService;
    }
    
    //Todo: Пересмотреть удаление, и получение удаленных записей, потому что по факту в БД они занимают alias, даже если удалены
    public async Task Handle(DeleteMediaCommand request, CancellationToken cancellationToken)
    {
        var media = await _mediaService.GetMediaAsync(request.MediaId, false, false, cancellationToken);
        if(media == null)
            throw new MediaNotFoundException(request.MediaId);
        
        await _mediaService.DeleteMediaAsync(media, cancellationToken);
        await _mediaService.SaveChangesAsync(cancellationToken);
    }
}