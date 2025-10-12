using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Storage.DownloadMediaVideo;

public record DownloadMediaVideoQuery(string Alias, string EpisodeNumber) : IRequest<Stream>
{
}