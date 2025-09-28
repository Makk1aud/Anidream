using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Storage.DownloadMediaImage;

public record DownloadMediaImageCommand(string Alias) : IRequest<Stream>
{
}