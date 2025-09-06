using Anidream.Api.Application.UseCases.Services.Interfaces;
using Anidream.Api.Application.Utils.Dtos;
using Anidream.Api.Application.Utils.Exceptions;
using AutoMapper;
using MediatR;

namespace Anidream.Api.Application.Utils.Handlers.Media.GetMediaById;

public class GetMediaByIdCommandHandler : IRequestHandler<GetMediaByIdCommand, MediaDto>
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
            await _mediaService.GetMediaAsync(request.MediaId, cancellationToken)
            ?? throw new MediaNotFoundException($"Media с id: {request.MediaId} не найдено");
        var mediaDto = _mapper.Map<MediaDto>(media);
        return mediaDto;
    }
}