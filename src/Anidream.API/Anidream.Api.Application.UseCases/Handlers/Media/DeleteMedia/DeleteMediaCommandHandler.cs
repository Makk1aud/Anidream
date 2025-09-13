using Anidream.Api.Application.Core;
using Anidream.Api.Application.Shared.Exceptions;
using MediatR;

namespace Anidream.Api.Application.Utils.Handlers.Media.DeleteMedia;

public class DeleteMediaCommandHandler : IRequestHandler<DeleteMediaCommand>
{
    private readonly IMediaService _mediaService;

    public DeleteMediaCommandHandler(IMediaService mediaService)
    {
        _mediaService = mediaService;
    }
    
    public async Task Handle(DeleteMediaCommand request, CancellationToken cancellationToken)
    {
        var media = await _mediaService.GetMediaAsync(request.MediaId, false, cancellationToken);
        if(media == null)
            throw new MediaNotFoundException(request.MediaId.ToString());
        
        media.IsDeleted = true;
        await _mediaService.SaveChangesAsync(cancellationToken);
    }
}