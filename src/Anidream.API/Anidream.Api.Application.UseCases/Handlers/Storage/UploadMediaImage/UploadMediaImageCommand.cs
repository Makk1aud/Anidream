using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Storage.UploadMediaImage;

public record UploadMediaImageCommand(string Alias, Stream FileStream, string FileExtension) : IRequest
{
}