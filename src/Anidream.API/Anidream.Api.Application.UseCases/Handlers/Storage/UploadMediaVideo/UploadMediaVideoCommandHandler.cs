using Anidream.Api.Application.Core;
using Anidream.Api.Application.Shared;
using Anidream.Api.Application.Shared.Exceptions;
using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Storage.UploadMediaVideo;

internal sealed class UploadMediaVideoCommandHandler : IRequestHandler<UploadMediaVideoCommand>
{
    private readonly IMediaService _mediaService;
    private readonly IMediaStorageService _mediaStorageService;

    public UploadMediaVideoCommandHandler(IMediaService mediaService, IMediaStorageService mediaStorageService)
    {
        _mediaService = mediaService;
        _mediaStorageService = mediaStorageService;
    }
    
    public async Task Handle(UploadMediaVideoCommand request, CancellationToken cancellationToken)
    {
        var media = await _mediaService.GetMediaByAliasAsync(request.Alias, cancellationToken: cancellationToken);
        if (media == null)
            throw new MediaNotFoundException(request.Alias);
        
        if(!ValidateFileEpisodeNumber(media, request.EpisodeNumber))
            throw new MediaBadRequestException("Uploading file episode must be lower or equal to number of episodes.");
        
        await _mediaStorageService.UploadVideoAsync(
            request.FileStream,
            Constants.FileStorage.VideoExtension,
            request.Alias,
            request.EpisodeNumber,
            cancellationToken); 
    }
    
    private bool ValidateFileEpisodeNumber(Domain.Entities.Media media, string episodeNumber) => 
        int.TryParse(episodeNumber, out int episodeNumberInt) && media.TotalEpisodes > 0 && media.TotalEpisodes >= episodeNumberInt;
}