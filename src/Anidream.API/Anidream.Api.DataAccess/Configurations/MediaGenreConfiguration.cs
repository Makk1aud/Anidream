using Anidream.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anidream.Api.DataAccess.Configurations;

public class MediaGenreConfiguration : IEntityTypeConfiguration<MediaGenre>
{
    public void Configure(EntityTypeBuilder<MediaGenre> builder)
    {
        builder.ToTable(Constants.TableNames.MediaGenres);
        builder.HasKey(nameof(MediaGenre.MediaId), nameof(MediaGenre.GenreId));

        // builder
        //     .HasOne(x => x.Media)
        //     .WithMany(x => x.MediaGenres)
        //     .HasForeignKey(x => x.MediaId);
        //
        // builder.HasOne(x => x.Genre)
        //     .WithMany(x => x.MediaGenres)
        //     .HasForeignKey(x => x.GenreId);
    }
}