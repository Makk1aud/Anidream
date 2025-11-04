using MediatR;

namespace Anidream.Application.UseCases.Handlers.Storage.UploadMediaImage;

public record UploadMediaImageCommand(string Alias, Stream FileStream, string FileExtension) : IRequest
{
}