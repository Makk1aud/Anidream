using MediatR;

namespace Anidream.Application.UseCases.Handlers.Media.SetDeleteMediaStatus;

public record SetDeleteMediaStatusCommand(Guid MediaId) : IRequest
{
}