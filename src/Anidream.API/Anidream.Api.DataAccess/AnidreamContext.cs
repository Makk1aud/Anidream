using Anidream.Api.Application.Core;
using Microsoft.EntityFrameworkCore;
using Anidream.Api.DataAccess.Configurations;
using Anidream.Api.Domain.Entities;

namespace Anidream.Api.DataAccess;

public sealed class AnidreamContext : DbContext, IDbContext
{
    public DbSet<Media> Medias { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Studio> Studios { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<MediaGenre> MediaGenres { get; set; }

    public AnidreamContext(DbContextOptions<AnidreamContext> options)
        : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MediaConfiguration());
        modelBuilder.ApplyConfiguration(new DirectorConfiguration());
        modelBuilder.ApplyConfiguration(new StudioConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new MediaGenreConfiguration());
    }
}