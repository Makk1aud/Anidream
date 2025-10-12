using Anidream.Api.Application.Core;
using Anidream.Api.Application.Shared.Exceptions;

namespace Anidream.Api.Application.Services;

public class MediaStorageService : IMediaStorageService
{
    private readonly IStorageConnectionProvider _storageConnectionProvider;
    private readonly IFileStorageClient _fileStorageClient;
    public MediaStorageService(IStorageConnectionProvider storageConnectionProvider, IFileStorageClient fileStorageClient)
    {
        _storageConnectionProvider = storageConnectionProvider;
        _fileStorageClient = fileStorageClient;
    }

    //Todo: надо поддерживать правильных формат расширений
    public Task UploadImageAsync(Stream stream, string fileExtension, string alias, CancellationToken cancellationToken = default)
    {
        var newFileName = Path.ChangeExtension(alias, fileExtension);
        var basePath = _storageConnectionProvider.GetStorageImageFolderPath();
        var filePath = Path.Combine(basePath, newFileName);
        return _fileStorageClient.SaveFileAsync(stream, filePath, cancellationToken);
    }
    
    public Task<Stream> DownloadImageAsync(string alias, CancellationToken cancellationToken = default)
    {
        var basePath = _storageConnectionProvider.GetStorageImageFolderPath();
        var filePath = Directory.GetFiles(basePath, $"{alias}.*").SingleOrDefault();
        if(string.IsNullOrEmpty(filePath))
            throw new StorageException($"File {Path.GetFileName(filePath)} was not found");
        
        return _fileStorageClient.GetFileStreamAsync(filePath, cancellationToken);
    }
    
    public Task<Stream> DownloadVideoAsync(string alias, string episodeNumber, CancellationToken cancellationToken = default)
    {
        var basePath = Path.Combine(_storageConnectionProvider.GetStorageVideoFolderPath(), alias);
        var filePath = Directory.GetFiles(basePath, $"{episodeNumber}.*").SingleOrDefault();
        if(string.IsNullOrEmpty(filePath))
            throw new StorageException($"Video {alias} with episode {episodeNumber} was not found");
        
        return _fileStorageClient.GetFileStreamAsync(filePath, cancellationToken);
    }

    public Task UploadVideoAsync(
        Stream stream,
        string fileExtension,
        string alias,
        string episodeNumber,
        CancellationToken cancellationToken = default)
    {
        var newFileName = Path.ChangeExtension(episodeNumber, fileExtension);
        var basePath = Path.Combine(_storageConnectionProvider.GetStorageVideoFolderPath(), alias);
        Directory.CreateDirectory(basePath);
        
        var filePath = Path.Combine(basePath, newFileName);
        return _fileStorageClient.SaveFileAsync(stream, filePath, cancellationToken);
    }

    public Task<IReadOnlyCollection<string>> GetVideoEpisodesAsync(string alias, CancellationToken cancellationToken = default)
    {
        var basePath = Path.Combine(_storageConnectionProvider.GetStorageVideoFolderPath(), alias);
        return Task.FromResult<IReadOnlyCollection<string>>(Directory.GetFiles(basePath).Select(Path.GetFileNameWithoutExtension).ToList()!);
    }
}
