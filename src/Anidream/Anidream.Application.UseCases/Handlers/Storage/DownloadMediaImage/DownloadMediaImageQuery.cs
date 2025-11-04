using MediatR;

namespace Anidream.Application.UseCases.Handlers.Storage.DownloadMediaImage;

public record DownloadMediaImageQuery(string Alias) : IRequest<Stream>
{
}