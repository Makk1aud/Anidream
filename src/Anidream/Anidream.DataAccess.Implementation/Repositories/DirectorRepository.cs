using Anidream.Application.Interfaces;
using Anidream.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anidream.DataAccess.Implementation;

public class DirectorRepository : BaseRepository<Director>, IDirectorRepository
{
    public DirectorRepository(AnidreamContext dbContext) : base(dbContext)
    { }

    public async Task<IEnumerable<Director>> GetDirectorsAsync(bool tracking = false, CancellationToken cancellationToken = default) =>
        await FindAll(tracking).ToListAsync(cancellationToken: cancellationToken);

    public Task<Director?> GetDirectorAsync(Guid id, bool tracking = false, CancellationToken cancellationToken = default) =>
        FindByExpression(x => x.DirectorId == id, tracking).SingleOrDefaultAsync(cancellationToken: cancellationToken);

    public async Task<Director> AddDirectorAsync(Director director, CancellationToken cancellationToken = default) =>
        (await CreateAsync(director, cancellationToken)).Entity;

    public Task<Director> UpdateDirectorAsync(Director director, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Update(director));
    }

    public Task DeleteDirectorAsync(Director director, CancellationToken cancellationToken = default)
    {
        Delete(director);
        return Task.CompletedTask;
    }
}