using MediatR;

namespace Anidream.Application.UseCases.Handlers.Genre.DeleteGenre;

public record DeleteGenreCommand(Guid GenreId) : IRequest
{ }