using System.Globalization;
using Anidream.Api.Application.Core;
using Anidream.Api.Application.Options;
using Anidream.Api.Application.Shared.Exceptions;
using Microsoft.Extensions.Options;

namespace Anidream.Api.Application.Services;

public class StorageService : IStorageService
{
    private readonly StorageOptions _options;

    public StorageService(IOptions<StorageOptions> options)
    {
        _options = options.Value;
    }

    public async Task UploadImageAsync(Stream stream, string fileName, CancellationToken cancellationToken = default)
    {
        var basePath = GetBasePath(_options.ImageFolder);
        var filePath = Path.Combine(basePath, fileName);
        Console.WriteLine(basePath);
        Directory.CreateDirectory(basePath);
        await using var fileStream = new FileStream(filePath, FileMode.Create);
        await stream.CopyToAsync(fileStream, cancellationToken);
    }
    
    //Todo: Возможно переделать под общий метод получения потока 
    public async Task<Stream> DownloadFileAsync(string fileName, CancellationToken cancellationToken = default)
    {
        try
        {
            var basePath = GetBasePath(_options.VideoFolder);
            var filePath = Path.Combine(GetBasePath(_options.ImageFolder), fileName);
            
            Directory.CreateDirectory(basePath);
            await using var fileStream = new FileStream(filePath, FileMode.Open);
            var memoryStream = new MemoryStream();
            await fileStream.CopyToAsync(memoryStream, cancellationToken);
            return memoryStream;
        }
        catch (Exception e)
        {
            throw new StorageException("Error downloading file", e);
        }
    }
    
    private string GetBasePath(string relativeFolder) =>
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _options.StorageBasePath, relativeFolder);
}