using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Storage.DownloadMediaImage;

public record DownloadMediaImageQuery(string Alias) : IRequest<Stream>
{
}