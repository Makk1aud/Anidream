using Anidream.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anidream.DataAccess.Configurations;

public class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.ToTable(Constants.TableNames.Directors);
        builder.HasKey(x => x.DirectorId);
        builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);
    }
}