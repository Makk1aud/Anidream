using Anidream.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anidream.Api.DataAccess.Configurations;

public class MediaConfiguration : IEntityTypeConfiguration<Media>
{
    public void Configure(EntityTypeBuilder<Media> builder)
    {
        builder.HasKey(x => x.MediaId);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(250);
        builder.Property(x => x.Alias).IsRequired().HasMaxLength(250);
        builder.Property(x => x.Description).IsRequired();
        
        builder.HasOne(x => x.Studio)
            .WithMany(x => x.Medias)
            .HasForeignKey(x => x.StudioId);
        
        builder.HasOne(x => x.Director)
            .WithMany(x => x.Medias)
            .HasForeignKey(x => x.DirectorId);
        
        builder.Property(x => x.ReleaseDate);
        builder.Property(x => x.Rating);
        builder.Property(x => x.TotalEpisodes);
        builder.Property(x => x.CurrentEpisodes);
    }
}