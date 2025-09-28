using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Storage.UploadMediaVideo;

public record UploadMediaVideoCommand(string Alias, string EpisodeNumber, Stream FileStream) : IRequest
{
}