using Anidream.Application.Contracts.Director;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Director.GetDirectors;

public record GetListOfDirectorsQuery : IRequest<IReadOnlyCollection<DirectorResponse>>
{
    
}