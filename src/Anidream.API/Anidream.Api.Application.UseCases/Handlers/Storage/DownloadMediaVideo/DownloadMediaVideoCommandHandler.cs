using Anidream.Api.Application.Core;
using Anidream.Api.Application.Shared.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Anidream.Api.Application.UseCases.Handlers.Storage.DownloadMediaVideo;

internal sealed class DownloadMediaVideoCommandHandler : IRequestHandler<DownloadMediaVideoCommand, Stream>
{
    private readonly IMediaService _mediaService;
    private readonly IMediaStorageService _mediaStorageService;
    private readonly ILogger<DownloadMediaVideoCommandHandler> _logger;

    public DownloadMediaVideoCommandHandler(
        IMediaService mediaService,
        IMediaStorageService mediaStorageService,
        ILogger<DownloadMediaVideoCommandHandler> logger)
    {
        _mediaService = mediaService;
        _mediaStorageService = mediaStorageService;
        _logger = logger;
    }
    
    //Todo: сделать обертку которая будет иметь методы для выкидывания Exception на null результат, типо GetMediaByAliasAsyncAndThrowExceptionsIfNotExist
    public async Task<Stream> Handle(DownloadMediaVideoCommand request, CancellationToken cancellationToken)
    {
        var media = await _mediaService.GetMediaByAliasAsync(request.Alias, cancellationToken: cancellationToken);
        if(media == null)
            throw new MediaNotFoundException(request.Alias);
        
        _logger.LogInformation("Downloading media video {Alias} episode {Episode}", request.Alias, request.EpisodeNumber);
        return await _mediaStorageService.DownloadVideoAsync(request.Alias, request.EpisodeNumber, cancellationToken);
    }
}