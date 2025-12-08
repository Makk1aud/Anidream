using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using Anidream.Domain.Entities;

namespace Anidream.Application.Services;

public static class RepositoryHelper
{
    public static async Task<IEnumerable<Genre>> GetGenresByIdsAsync(
        IGenreRepository genreRepository,
        IReadOnlyCollection<Guid> genreIds,
        CancellationToken cancellationToken)
    {
        var genres = new List<Genre>();
        foreach (var genreId in genreIds)
        {
            var genre = await genreRepository.GetGenreAsync(genreId, cancellationToken: cancellationToken)
                        ?? throw new EntityNotFoundException(nameof(Genre), genreId.ToString());
            genres.Add(genre);
        }

        return genres;
    }
}