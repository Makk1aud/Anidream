using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using Anidream.Domain.Entities;

namespace Anidream.Application.Services;

public static class RepositoryHelper
{
    public static async Task<IEnumerable<Genre>> GetGenresByIdsAsync(
        IGenreRepository genreRepository,
        IReadOnlyCollection<Guid> genreIds,
        CancellationToken cancellationToken) =>
            await Task.WhenAll(genreIds.Select(async x => 
                await genreRepository.GetGenreAsync(x, cancellationToken: cancellationToken)
                ?? throw new EntityNotFoundException(nameof(Genre), x.ToString())));
}