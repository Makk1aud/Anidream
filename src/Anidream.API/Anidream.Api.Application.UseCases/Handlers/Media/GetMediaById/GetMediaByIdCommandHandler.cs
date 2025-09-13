using Anidream.Api.Application.Core;
using Anidream.Api.Application.Shared.Exceptions;
using Anidream.Api.Application.Utils.Dtos;
using AutoMapper;
using MediatR;

namespace Anidream.Api.Application.Utils.Handlers.Media.GetMediaById;

internal sealed class GetMediaByIdCommandHandler : IRequestHandler<GetMediaByIdCommand, MediaDto>
{
    private readonly IMediaService _mediaService;
    private readonly IMapper _mapper;

    public GetMediaByIdCommandHandler(IMediaService mediaService, IMapper mapper)
    {
        _mediaService = mediaService;
        _mapper = mapper;
    }
    
    public async Task<MediaDto> Handle(GetMediaByIdCommand request, CancellationToken cancellationToken)
    {
        var media = 
            await _mediaService.GetMediaAsync(request.MediaId, cancellationToken:  cancellationToken)
            ?? throw new MediaNotFoundException(request.MediaId.ToString());
        var mediaDto = _mapper.Map<MediaDto>(media);
        return mediaDto;
    }
}