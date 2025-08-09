using Anidream.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anidream.Api.DataAccess.Configurations;

public class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.HasKey(x => x.DirectorId);
        builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);
    }
}