namespace Anidream.Api.Application.Core;

public interface IStorageService
{
    public Task UploadImageAsync(Stream stream, string fileName, string mediaId, CancellationToken cancellationToken = default);
    public Task<MemoryStream> DownloadImageAsync(string mediaId, CancellationToken cancellationToken = default);
}