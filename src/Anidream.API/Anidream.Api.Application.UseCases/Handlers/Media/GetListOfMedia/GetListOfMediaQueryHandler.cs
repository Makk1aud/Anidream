using Anidream.Api.Application.Core;
using Anidream.Api.Application.Shared.Entities;
using Anidream.Api.Application.Utils.Dtos;
using AutoMapper;
using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Media.GetListOfMedia;

internal sealed class GetListOfMediaQueryHandler : IRequestHandler<GetListOfMediaQuery, (IEnumerable<MediaDto> Medias, PaginationMetadata Metadata)>
{
    private readonly IMediaService _mediaService;
    private readonly IMapper _mapper;

    public GetListOfMediaQueryHandler(IMediaService mediaService, IMapper mapper)
    {
        _mediaService = mediaService;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<MediaDto> Medias, PaginationMetadata Metadata)> Handle(GetListOfMediaQuery request, CancellationToken cancellationToken)
    {
        var pagedMedias = await _mediaService.GetMediasAsync(request.Filter, request.PaginationOptions, cancellationToken: cancellationToken);
        var mediasDto = _mapper.Map<IEnumerable<MediaDto>>(pagedMedias); 
        return (mediasDto, pagedMedias.GetMetadata());
    }
}