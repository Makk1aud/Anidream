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

    public AnidreamContext(DbContextOptions<AnidreamContext> options)
        : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Media>().ToTable(Constants.Database.MediaTableName);
        modelBuilder.Entity<Director>().ToTable(Constants.Database.DirectorTableName);
        modelBuilder.Entity<Studio>().ToTable(Constants.Database.StudioTableName);
           
        modelBuilder.ApplyConfiguration(new MediaConfiguration());
        modelBuilder.ApplyConfiguration(new DirectorConfiguration());
        modelBuilder.ApplyConfiguration(new StudioConfiguration());
    }
}