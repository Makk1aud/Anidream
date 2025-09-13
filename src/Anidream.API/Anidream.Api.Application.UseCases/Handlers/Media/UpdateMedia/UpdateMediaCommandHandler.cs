using Anidream.Api.Application.Core;
using Anidream.Api.Application.Shared.Exceptions;
using Anidream.Api.Application.Utils.Dtos;
using AutoMapper;
using MediatR;

namespace Anidream.Api.Application.Utils.Handlers.Media.UpdateMedia;

internal sealed class UpdateMediaCommandHandler : IRequestHandler<UpdateMediaCommand, MediaDto>
{
    private readonly IMediaService _mediaService;
    private readonly IMapper _mapper;

    public UpdateMediaCommandHandler(IMediaService  mediaService, IMapper mapper)
    {
        _mediaService = mediaService;
        _mapper = mapper;
    }
    
    public async Task<MediaDto> Handle(UpdateMediaCommand request, CancellationToken cancellationToken)
    {
        var media = await _mediaService.GetMediaAsync(request.MediaId, cancellationToken: cancellationToken);
        if (media == null)
            throw new MediaNotFoundException(request.MediaId.ToString());
                
        _mapper.Map(request.Dto, media);
        await _mediaService.SaveChangesAsync(cancellationToken);
            
        return _mapper.Map<MediaDto>(media);
    }
}