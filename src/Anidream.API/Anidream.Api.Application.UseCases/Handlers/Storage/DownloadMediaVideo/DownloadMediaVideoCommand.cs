using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Storage.DownloadMediaVideo;

public record DownloadMediaVideoCommand(string Alias, string EpisodeNumber) : IRequest<Stream>
{
}