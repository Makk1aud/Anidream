using Anidream.Domain.Entities;

namespace Anidream.Application.Interfaces;

public interface IGenreRepository
{
    public Task<IEnumerable<Genre>> GetGenresAsync(
        bool tracking = false,
        CancellationToken cancellationToken = default);
    
    public Task<Genre?> GetGenreAsync(Guid id, bool tracking = false, CancellationToken cancellationToken = default);
    public Task<Genre?> GetGenreByAliasAsync(string alias, bool tracking = false,CancellationToken cancellationToken = default);
    
    public Task<Genre> AddGenreAsync(Genre genre, CancellationToken cancellationToken = default);
    
    public Task DeleteGenreAsync(Genre genre, CancellationToken cancellationToken = default);
}