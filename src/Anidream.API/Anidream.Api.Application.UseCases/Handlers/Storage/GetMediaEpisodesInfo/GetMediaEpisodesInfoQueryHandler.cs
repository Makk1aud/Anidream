using Anidream.Api.Application.Core;
using Anidream.Api.Application.Shared.Exceptions;
using Anidream.Api.Application.Utils.Dtos;
using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Storage.GetMediaEpisodesInfo;

internal sealed class GetMediaEpisodesInfoQueryHandler : IRequestHandler<GetMediaEpisodesInfoQuery, EpisodesInfoDto>
{
    private readonly IMediaStorageService _mediaStorageService;
    private readonly IMediaService _mediaService;

    public GetMediaEpisodesInfoQueryHandler(IMediaStorageService mediaStorageService, IMediaService mediaService)
    {
        _mediaStorageService = mediaStorageService;
        _mediaService = mediaService;
    }
    
    public async Task<EpisodesInfoDto> Handle(GetMediaEpisodesInfoQuery request, CancellationToken cancellationToken)
    {
        var media = await _mediaService.GetMediaByAliasAsync(request.MediaAlias, cancellationToken: cancellationToken); 
        
        if(media is null)
            throw new MediaNotFoundException(request.MediaAlias);
        return new EpisodesInfoDto(request.MediaAlias, await _mediaStorageService.GetVideoEpisodesAsync(request.MediaAlias, cancellationToken));
    }
}