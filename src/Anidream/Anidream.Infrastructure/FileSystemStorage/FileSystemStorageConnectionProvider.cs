using Anidream.Infrastructure.FileSystemStorage.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Anidream.Infrastructure.FileSystemStorage;

public class FileSystemStorageConnectionProvider : IStorageConnectionProvider
{
    private readonly ILogger<FileSystemStorageConnectionProvider> _logger;
    private readonly FileSystemStorageOptions _options;
    
    public FileSystemStorageConnectionProvider(IOptions<FileSystemStorageOptions> storageOptions, ILogger<FileSystemStorageConnectionProvider> logger)
    {
        _logger = logger;
        _options = storageOptions.Value;
    }
    
    private string GetBasePathAndCreateDirectory(string folder)
    {
        var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _options.StorageBasePath, folder);
        _logger.LogInformation("Creating directory {BasePath}", basePath);
        Directory.CreateDirectory(basePath);
        return basePath;
    }

    public string GetStorageImageFolderPath() => GetBasePathAndCreateDirectory(_options.ImageFolder);

    public string GetStorageVideoFolderPath() => GetBasePathAndCreateDirectory(_options.VideoFolder);
}