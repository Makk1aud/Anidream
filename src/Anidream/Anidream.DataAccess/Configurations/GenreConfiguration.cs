using Anidream.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anidream.DataAccess.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable(Constants.TableNames.Genres);
        builder.HasKey(x => x.GenreId);
        
        builder.HasIndex(x => x.Title).IsUnique();
        builder.Property(x => x.Title).IsRequired();
        
        builder.HasIndex(x => x.Alias).IsUnique();
        builder.Property(x => x.Alias).IsRequired();
    }
}