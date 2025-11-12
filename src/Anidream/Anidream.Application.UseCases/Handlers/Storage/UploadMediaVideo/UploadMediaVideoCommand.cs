using MediatR;

namespace Anidream.Application.UseCases.Handlers.Storage.UploadMediaVideo;

public record UploadMediaVideoCommand(string Alias, string EpisodeNumber, Stream FileStream, string FileName) : IRequest
{
}