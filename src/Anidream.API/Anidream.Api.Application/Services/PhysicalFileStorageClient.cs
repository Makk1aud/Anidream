using Anidream.Api.Application.Core;
using Anidream.Api.Application.Shared.Exceptions;

namespace Anidream.Api.Application.Services;

public class PhysicalFileStorageClient : IFileStorageClient, IDisposable
{
    public async Task<Stream> GetFileStreamAsync(string filePath, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var fileStream = File.OpenRead(filePath);
            var memoryStream = new MemoryStream();
            await fileStream.CopyToAsync(memoryStream, cancellationToken);
            memoryStream.Position = 0;
            return memoryStream;
        }
        catch (FileNotFoundException)
        {
            throw new StorageException("File not found");
        }
        catch (Exception e)
        {
            throw new StorageException("Error while downloading file", e);
        }
    }

    public async Task SaveFileAsync(Stream stream, string filePath, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var fileStream = new FileStream(filePath, FileMode.Create);
            await stream.CopyToAsync(fileStream, cancellationToken);
        }
        catch (Exception e)
        {
            throw new StorageException("Error while saving file", e);
        }
    }
    
    public void Dispose()
    {
        // TODO release managed resources here
    }
}