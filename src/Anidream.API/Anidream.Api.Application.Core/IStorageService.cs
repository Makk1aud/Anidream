namespace Anidream.Api.Application.Core;

public interface IStorageService
{
    public Task UploadImageAsync(Stream stream, string fileName, CancellationToken cancellationToken = default);
    public Task<Stream> DownloadFileAsync(string fileName, CancellationToken cancellationToken = default);
}