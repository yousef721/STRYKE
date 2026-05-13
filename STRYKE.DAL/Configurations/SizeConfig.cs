using System;

namespace STRYKE.DAL.Configurations;

public class SizeConfig : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {
        builder.HasKey(x => x.SizeId);

        // Properties
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(20);

        // Indexes
        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}
