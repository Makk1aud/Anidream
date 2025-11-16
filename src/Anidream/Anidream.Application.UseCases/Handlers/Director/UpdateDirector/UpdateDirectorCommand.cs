using Anidream.Application.Contracts.Director;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Director.UpdateDirector;

public record UpdateDirectorCommand(Guid DirectorId, DirectorRequest Request) : IRequest<DirectorResponse>
{ }