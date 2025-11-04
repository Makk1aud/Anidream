using Anidream.Application.Contracts;
using Anidream.Application.Contracts.Media;
using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Media.GetMediaById;

internal sealed class GetMediaByIdQueryHandler : IRequestHandler<GetMediaByIdQuery, MediaResponse>
{
    private readonly IMediaRepository _mediaService;
    private readonly IMapper _mapper;

    public GetMediaByIdQueryHandler(IMediaRepository mediaService, IMapper mapper)
    {
        _mediaService = mediaService;
        _mapper = mapper;
    }
    
    public async Task<MediaResponse> Handle(GetMediaByIdQuery request, CancellationToken cancellationToken)
    {
        var media = 
            await _mediaService.GetMediaAsync(request.MediaId, cancellationToken:  cancellationToken)
            ?? throw new MediaNotFoundException(request.MediaId);
        var mediaDto = _mapper.Map<MediaResponse>(media);
        return mediaDto;
    }
}