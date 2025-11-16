using Anidream.Application.Contracts.Director;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Director.GetDirectorById;

public record GetDirectorByIdQuery(Guid DirectorId) : IRequest<DirectorResponse>
{ }