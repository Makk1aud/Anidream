using MediatR;

namespace Anidream.Application.UseCases.Handlers.Media.DeleteMedia;

public record DeleteMediaCommand(Guid MediaId) : IRequest
{
}