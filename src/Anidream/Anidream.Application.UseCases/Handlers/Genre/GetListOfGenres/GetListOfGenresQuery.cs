using Anidream.Application.Contracts.Genre;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Genre.GetListOfGenres;

public record GetListOfGenresQuery : IRequest<IReadOnlyList<GenreResponse>>
{
    
}