using Anidream.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anidream.Api.Application.Core;

public interface IDbContext
{
    public DbSet<Media> Medias { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Studio> Studios { get; set; }
    
    public DbSet<TEntity> Set<TEntity>() where TEntity : class;
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}