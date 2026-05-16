namespace STRYKE.DAL.Configurations;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.CategoryId);

        // Properties
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Image)
            .HasMaxLength(500);

        // Indexes
        builder.HasIndex(x => x.Name)
            .IsUnique();

        // Constraints
        builder.ToTable(t =>
        {
            // Category name cannot be empty or spaces
            t.HasCheckConstraint(
                "chk_category_name_not_empty",
                "TRIM(Name) <> ''");

            // Validate hex code format: #RRGGBB or #RRGGBBAA
            t.HasCheckConstraint(
                "chk_color_hex_format",
                "HexCode IS NULL OR " +
                "(HexCode LIKE '#[0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f]' " +
                "OR HexCode LIKE '#[0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f]')");
        });
  
        builder.HasCheckConstraint("chk_color_hex_format",
        "HexCode IS NULL OR (HexCode LIKE '#%' AND (LEN(HexCode) = 7 OR LEN(HexCode) = 9))");
    }
}
