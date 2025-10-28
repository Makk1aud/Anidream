using Anidream.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anidream.Api.DataAccess.Configurations;

public class MediaConfiguration : IEntityTypeConfiguration<Media>
{
    public void Configure(EntityTypeBuilder<Media> builder)
    {
        builder.ToTable(Constants.TableNames.Medias);
        builder.HasKey(x => x.MediaId);
        
        builder.HasIndex(x => x.Title).IsUnique();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(250);
        
        builder.HasIndex(x => x.Alias).IsUnique();
        builder.Property(x => x.Alias).IsRequired().HasMaxLength(250);
        
        builder.Property(x => x.Description).IsRequired();

        builder
            .HasOne(x => x.Studio)
            .WithMany(x => x.Medias)
            .HasForeignKey(x => x.StudioId)
            .IsRequired(false);

        builder
            .HasOne(x => x.Director)
            .WithMany(x => x.Medias)
            .HasForeignKey(x => x.DirectorId)
            .IsRequired(false);

        builder.HasMany(x => x.Genres).WithMany(x => x.Medias).UsingEntity<MediaGenre>();
        
        //AutoInclude
        builder.Navigation(x => x.Genres).AutoInclude();
        builder.Navigation(x => x.Studio).AutoInclude();
        builder.Navigation(x => x.Director).AutoInclude();
        
        builder.Property(x => x.ReleaseDate).IsRequired();
        builder.Property(x => x.Rating);
        builder.Property(x => x.TotalEpisodes);
        builder.Property(x => x.CurrentEpisodes);
        builder.Property(x => x.IsDeleted);
        builder.Property(x => x.HasImage);
    }
}