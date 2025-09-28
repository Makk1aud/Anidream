using Anidream.Api.Application.Core;
using Anidream.Api.Application.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Anidream.Api.Application.Services;

public class StorageConnectionProvider : IStorageConnectionProvider
{
    private readonly ILogger<StorageConnectionProvider> _logger;
    private readonly StorageOptions _options;
    
    public StorageConnectionProvider(IOptions<StorageOptions> storageOptions, ILogger<StorageConnectionProvider> logger)
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