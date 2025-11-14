using Anidream.Application.Contracts.Genre;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Genre.GetGenreByAlias;

public record GetGenreByAliasQuery(string Alias) : IRequest<GenreResponse>
{ }