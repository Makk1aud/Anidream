using Anidream.Application.Contracts;
using Anidream.Application.Contracts.Media;
using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Storage.GetMediaEpisodesInfo;

internal sealed class GetMediaEpisodesInfoQueryHandler : IRequestHandler<GetMediaEpisodesInfoQuery, EpisodesResponse>
{
    private readonly IMediaStorageService _mediaStorageService;
    private readonly IMediaRepository _mediaService;

    public GetMediaEpisodesInfoQueryHandler(IMediaStorageService mediaStorageService, IMediaRepository mediaService)
    {
        _mediaStorageService = mediaStorageService;
        _mediaService = mediaService;
    }
    
    public async Task<EpisodesResponse> Handle(GetMediaEpisodesInfoQuery request, CancellationToken cancellationToken)
    {
        var media = await _mediaService.GetMediaByAliasAsync(request.MediaAlias, cancellationToken: cancellationToken); 
        
        if(media is null)
            throw new MediaNotFoundException(request.MediaAlias);
        return new EpisodesResponse(request.MediaAlias, await _mediaStorageService.GetVideoEpisodesAsync(request.MediaAlias, cancellationToken));
    }
}