using Anidream.Api.Application.Core;
using Anidream.Api.Application.Shared;
using Anidream.Api.Application.Utils.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Anidream.Api.Application.UseCases.Handlers.Media.GetListOfMedia;

internal sealed class GetListOfMediaCommandHandler : IRequestHandler<GetListOfMediaCommand, PaginationList<MediaDto>>
{
    private readonly IMediaService _mediaService;
    private readonly IMapper _mapper;

    public GetListOfMediaCommandHandler(IMediaService mediaService, IMapper mapper)
    {
        _mediaService = mediaService;
        _mapper = mapper;
    }

    public async Task<PaginationList<MediaDto>> Handle(GetListOfMediaCommand request, CancellationToken cancellationToken)
    {
        var medias = await _mediaService.GetMediasAsync(false, request.Filter, cancellationToken);
        var mediasDto = _mapper.Map<IReadOnlyCollection<MediaDto>>(medias); 
        
        return new PaginationList<MediaDto>(mediasDto, request.PaginationOptions.PageNumber, request.PaginationOptions.PageSize);
    }
}