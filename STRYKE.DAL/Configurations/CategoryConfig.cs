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
        });
    }
}
