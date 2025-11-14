using Anidream.Application.Contracts.Genre;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Genre.GetGenreById;

public record GetGenreByIdQuery(Guid GenreId) : IRequest<GenreResponse>
{ }