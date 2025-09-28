namespace Anidream.Api.Application.Core;

public interface IFileStorageClient
{
    public Task<Stream> GetFileStreamAsync(string filePath, CancellationToken cancellationToken = default);
    public Task SaveFileAsync(Stream stream, string filePath, CancellationToken cancellationToken = default);
}