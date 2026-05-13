namespace STRYKE.DAL.Configurations;

public class ColorConfig : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.HasKey(x => x.ColorId);

        // Properties
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.HexCode)
            .HasMaxLength(10);

        // Indexes
        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.HasIndex(x => x.HexCode)
            .IsUnique();
    }
}
