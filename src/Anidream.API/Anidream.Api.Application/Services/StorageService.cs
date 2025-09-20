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

    public async Task UploadImageAsync(Stream stream, string fileName, string mediaId, CancellationToken cancellationToken = default)
    {
        try
        {
            var newFileName = Path.ChangeExtension(mediaId, Path.GetExtension(fileName));
            var basePath = GetBasePathAndCreateDirectory(_options.ImageFolder);
            var filePath = Path.Combine(basePath, newFileName);
            
            await using var fileStream = new FileStream(filePath, FileMode.Create);
            await stream.CopyToAsync(fileStream, cancellationToken);
        }
        catch (Exception e)
        {
            throw new StorageException("Error while saving file", e);
        }
    }
    
    //Todo: Возможно переделать под общий метод получения потока 
    public async Task<MemoryStream> DownloadImageAsync(string mediaId, CancellationToken cancellationToken = default)
    {
        try
        {
            var basePath = GetBasePathAndCreateDirectory(_options.ImageFolder);
            var filePath = Directory.GetFiles(basePath, $"{mediaId}.*").SingleOrDefault();
            if(string.IsNullOrEmpty(filePath))
                throw new StorageException($"File {mediaId} not found");
            
            await using var fileStream = new FileStream(filePath, FileMode.Open);
            var memoryStream = new MemoryStream();
            await fileStream.CopyToAsync(memoryStream, cancellationToken);
            memoryStream.Position = 0;
            return memoryStream;
        }
        catch (Exception e)
        {
            throw new StorageException("Error downloading file", e);
        }
    }

    private string GetBasePathAndCreateDirectory(string folder)
    {
        var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _options.StorageBasePath, folder);
        Directory.CreateDirectory(basePath);
        return basePath;
    }
}