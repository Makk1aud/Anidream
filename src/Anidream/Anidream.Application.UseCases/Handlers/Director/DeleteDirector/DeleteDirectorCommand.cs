using MediatR;

namespace Anidream.Application.UseCases.Handlers.Director.DeleteDirector;

public record DeleteDirectorCommand(Guid DirectorId) : IRequest
{ }