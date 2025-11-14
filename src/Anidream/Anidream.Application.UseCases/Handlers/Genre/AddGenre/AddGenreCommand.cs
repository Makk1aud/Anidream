using Anidream.Application.Contracts.Genre;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Genre.AddGenre;

public record AddGenreCommand(GenreRequest Request) : IRequest<GenreResponse>
{ }