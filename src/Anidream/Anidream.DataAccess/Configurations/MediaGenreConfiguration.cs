using Anidream.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anidream.DataAccess.Configurations;

public class MediaGenreConfiguration : IEntityTypeConfiguration<MediaGenre>
{
    public void Configure(EntityTypeBuilder<MediaGenre> builder)
    {
        builder.ToTable(Constants.TableNames.MediaGenres);
        builder.HasKey(nameof(MediaGenre.MediaId), nameof(MediaGenre.GenreId));
    }
}