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
        
        builder.Property(x => x.Slug)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(c => c.Description)
            .HasMaxLength(1000);

        // Indexes
        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.HasIndex(x => x.Slug)
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
