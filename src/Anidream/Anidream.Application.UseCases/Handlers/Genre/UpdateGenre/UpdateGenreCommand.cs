using Anidream.Application.Contracts.Genre;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Genre.UpdateGenre;

public record UpdateGenreCommand(Guid GenreId, GenreRequest Request) : IRequest<GenreResponse>
{ }