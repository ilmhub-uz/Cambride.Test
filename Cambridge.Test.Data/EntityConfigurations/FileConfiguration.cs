using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Cambridge.Test.Data.EntityConfigurations;

public class FileConfiguration : IEntityTypeConfiguration<Abstractions.Entity.File>
{
    public void Configure(EntityTypeBuilder<Abstractions.Entity.File> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.Property(b => b.Filename).HasMaxLength(50).IsRequired();
        builder.Property(b => b.Extension).HasMaxLength(20).IsRequired();
        builder.Property(b => b.Path).ValueGeneratedOnAddOrUpdate();
    }
}