using Anidream.Application.Contracts;
using Anidream.Application.Contracts.Media;
using Anidream.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Media.GetListOfMedia;

internal sealed class GetListOfMediaQueryHandler : IRequestHandler<GetListOfMediaQuery, (IEnumerable<MediaResponse> Medias, PaginationMetadata Metadata)>
{
    private readonly IMediaRepository _mediaService;
    private readonly IMapper _mapper;

    public GetListOfMediaQueryHandler(IMediaRepository mediaService, IMapper mapper)
    {
        _mediaService = mediaService;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<MediaResponse> Medias, PaginationMetadata Metadata)> Handle(GetListOfMediaQuery request, CancellationToken cancellationToken)
    {
        var pagedMedias = await _mediaService.GetMediasAsync(request.Filter, request.PaginationOptions, cancellationToken: cancellationToken);
        var mediasDto = _mapper.Map<IEnumerable<MediaResponse>>(pagedMedias); 
        return (mediasDto, pagedMedias.GetMetadata());
    }
}