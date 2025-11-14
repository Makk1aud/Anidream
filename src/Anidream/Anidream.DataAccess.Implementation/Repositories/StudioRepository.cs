using Anidream.Application.Interfaces;
using Anidream.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anidream.DataAccess.Implementation;

public class StudioRepository : BaseRepository<Studio>, IStudioRepository
{
    public StudioRepository(AnidreamContext dbContext) : base(dbContext)
    { }

    public async Task<IEnumerable<Studio>> GetStudiosAsync(bool tracking = false, CancellationToken cancellationToken = default) =>
        await FindAll(tracking).ToListAsync(cancellationToken: cancellationToken);

    public Task<Studio?> GetStudioAsync(Guid id, bool tracking = false, CancellationToken cancellationToken = default) =>
        FindByExpression(x => x.StudioId == id, tracking).SingleOrDefaultAsync(cancellationToken: cancellationToken);

    public async Task<Studio> AddStudioAsync(Studio studio, CancellationToken cancellationToken = default) =>
       (await CreateAsync(studio, cancellationToken)).Entity;

    public Task<Studio> UpdateStudioAsync(Studio studio, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Update(studio));
    }

    public Task DeleteStudioAsync(Studio studio, CancellationToken cancellationToken = default) 
    {
        Delete(studio);
        return Task.CompletedTask;
    }
}