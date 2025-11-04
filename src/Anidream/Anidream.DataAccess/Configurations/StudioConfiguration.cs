using Anidream.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anidream.DataAccess.Configurations;

public class StudioConfiguration : IEntityTypeConfiguration<Studio>
{
    public void Configure(EntityTypeBuilder<Studio> builder)
    {
        builder.ToTable(Constants.TableNames.Studios);
        
        builder.HasKey(x => x.StudioId);
        builder.HasIndex(x => x.Title).IsUnique();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
    }
}