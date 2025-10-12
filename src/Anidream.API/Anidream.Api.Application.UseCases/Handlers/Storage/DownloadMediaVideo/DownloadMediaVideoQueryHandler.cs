using Anidream.Api.Application.Core;
using Anidream.Api.Application.Shared.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Anidream.Api.Application.UseCases.Handlers.Storage.DownloadMediaVideo;

internal sealed class DownloadMediaVideoQueryHandler : IRequestHandler<DownloadMediaVideoQuery, Stream>
{
    private readonly IMediaService _mediaService;
    private readonly IMediaStorageService _mediaStorageService;
    private readonly ILogger<DownloadMediaVideoQueryHandler> _logger;

    public DownloadMediaVideoQueryHandler(
        IMediaService mediaService,
        IMediaStorageService mediaStorageService,
        ILogger<DownloadMediaVideoQueryHandler> logger)
    {
        _mediaService = mediaService;
        _mediaStorageService = mediaStorageService;
        _logger = logger;
    }
    
    //Todo: сделать обертку которая будет иметь методы для выкидывания Exception на null результат, типо GetMediaByAliasAsyncAndThrowExceptionsIfNotExist
    public async Task<Stream> Handle(DownloadMediaVideoQuery request, CancellationToken cancellationToken)
    {
        //Todo: нет смысла проверять наличие в БД конкретного Media, потому что при работе с потоками в БД в секунду
        //летит по 10 запросов, да и ошибка об отсутствии эпизода прилетает с клиента фс 
        
        // var media = await _mediaService.GetMediaByAliasAsync(request.Alias, cancellationToken: cancellationToken);
        // if(media == null)
        //     throw new MediaNotFoundException(request.Alias);
        
        _logger.LogInformation("Downloading media video {Alias} episode {Episode}", request.Alias, request.EpisodeNumber);
        return await _mediaStorageService.DownloadVideoAsync(request.Alias, request.EpisodeNumber, cancellationToken);
    }
}