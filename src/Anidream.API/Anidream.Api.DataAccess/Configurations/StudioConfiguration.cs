using Anidream.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anidream.Api.DataAccess.Configurations;

public class StudioConfiguration : IEntityTypeConfiguration<Studio>
{
    public void Configure(EntityTypeBuilder<Studio> builder)
    {
        builder.HasKey(x => x.StudioId);
        builder.HasIndex(x => x.Title).IsUnique();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
    }
}