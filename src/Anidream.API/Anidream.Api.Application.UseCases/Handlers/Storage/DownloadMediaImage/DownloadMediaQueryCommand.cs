using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Storage.DownloadMediaImage;

public record DownloadMediaQueryCommand(string Alias) : IRequest<Stream>
{
}