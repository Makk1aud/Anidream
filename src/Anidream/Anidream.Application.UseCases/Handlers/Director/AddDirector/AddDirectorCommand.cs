using Anidream.Application.Contracts.Director;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Director.AddDirector;

public record AddDirectorCommand(DirectorRequest Request) : IRequest<DirectorResponse>
{ }