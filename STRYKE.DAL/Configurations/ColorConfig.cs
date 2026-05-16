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
        
        // Constraints
        builder.ToTable(t =>
        {
            // Color name cannot be empty or spaces
            t.HasCheckConstraint(
                "chk_color_name_not_empty",
                "TRIM(Name) <> ''");
                
            // Validate hex code format: #RRGGBB or #RRGGBBAA
            t.HasCheckConstraint(
                "chk_color_hex_format",
                "HexCode IS NULL OR " +
                "(HexCode LIKE '#[0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f]' " +
                "OR HexCode LIKE '#[0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f]')");
        });
    }
}
