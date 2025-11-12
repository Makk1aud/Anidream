using Anidream.Application.Interfaces;
using Anidream.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anidream.DataAccess.Implementation;

public class GenreRepository : BaseRepository<Genre>, IGenreRepository
{
    public GenreRepository(AnidreamContext dbContext)
        : base(dbContext)
    { }

    public async Task<IEnumerable<Genre>> GetGenresAsync(bool tracking = false, CancellationToken cancellationToken = default) =>
        await FindAll(tracking)
            .ToListAsync(cancellationToken);

    public Task<Genre?> GetGenreAsync(Guid id, bool tracking = false, CancellationToken cancellationToken = default) =>
        FindByExpression(x => x.GenreId == id, tracking)
            .SingleOrDefaultAsync(cancellationToken);

    public Task<Genre?> GetGenreByAliasAsync(string alias, bool tracking = false, CancellationToken cancellationToken = default) =>
        FindByExpression(x => x.Alias == alias, tracking)
            .SingleOrDefaultAsync(cancellationToken);

    public async Task<Genre> AddGenreAsync(Genre genre, CancellationToken cancellationToken = default) =>
        (await CreateAsync(genre, cancellationToken)).Entity;

    public Task DeleteGenreAsync(Genre genre, CancellationToken cancellationToken = default)
    {
        Delete(genre);
        return Task.CompletedTask;
    }
}