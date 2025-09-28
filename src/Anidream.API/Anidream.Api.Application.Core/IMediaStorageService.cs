namespace Anidream.Api.Application.Core;

public interface IMediaStorageService
{
    public Task UploadImageAsync(Stream stream, string fileExtension, string alias, CancellationToken cancellationToken = default);
    public Task<Stream> DownloadImageAsync(string alias, CancellationToken cancellationToken = default);
    public Task<Stream> DownloadVideoAsync(string alias, string episodeNumber, CancellationToken cancellationToken = default);
    public Task UploadVideoAsync(Stream stream, string fileExtension, string alias, string episodeNumber, CancellationToken cancellationToken = default);
}