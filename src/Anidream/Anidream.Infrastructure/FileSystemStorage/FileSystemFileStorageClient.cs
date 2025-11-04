using Anidream.Application.Exceptions;
using Anidream.Infrastructure.FileSystemStorage.Interfaces;

namespace Anidream.Infrastructure.FileSystemStorage;

public class FileSystemFileStorageClient : IFileStorageClient, IDisposable
{
    public Task<Stream> GetFileStreamAsync(string filePath, CancellationToken cancellationToken = default)
    {
        try
        {
            var fileStream = File.OpenRead(filePath);
            // var memoryStream = new MemoryStream();
            // await fileStream.CopyToAsync(memoryStream, cancellationToken);
            // memoryStream.Position = 0;
            // return memoryStream;
            return Task.FromResult<Stream>(fileStream);
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