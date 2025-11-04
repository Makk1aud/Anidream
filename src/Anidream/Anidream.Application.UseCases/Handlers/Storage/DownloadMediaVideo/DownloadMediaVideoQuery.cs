using MediatR;

namespace Anidream.Application.UseCases.Handlers.Storage.DownloadMediaVideo;

public record DownloadMediaVideoQuery(string Alias, string EpisodeNumber) : IRequest<Stream>
{
}