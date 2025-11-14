using MediatR;

namespace Anidream.Application.UseCases.Handlers.Studio.DeleteStudio;

public record DeleteStudioCommand(Guid StudioId) : IRequest
{ }