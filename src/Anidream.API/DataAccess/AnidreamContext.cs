using Application.Interfaces.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AnidreamContext : DbContext, IDbContext
{
    public DbSet<Media> Media { get; set; }

    public AnidreamContext(DbContextOptions<AnidreamContext> options) 
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Media
        modelBuilder.Entity<Media>().ToTable("Media");
        modelBuilder.Entity<Media>().HasKey(x => x.MediaId);
        modelBuilder.Entity<Media>().Property(x => x.MediaId)
            .HasMaxLength(150)
            .IsRequired();
    }
}