namespace STRYKE.DAL.Configurations;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.ProductId);

        // Properties
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Slug)
            .HasMaxLength(250);

        builder.Property(x => x.Description)
            .HasMaxLength(2000);

        builder.Property(x => x.Status)
            .HasConversion<int>()
            .IsRequired();

        // Total Participation: Product MUST belong to a Brand
        builder.Property(x => x.BrandId)
            .IsRequired();

        // Total Participation: Product MUST belong to a Category
        builder.Property(x => x.CategoryId)
            .IsRequired();


        // Relations
        // Total Participation: Product MUST belong to a Brand
        builder.HasOne(x => x.Brand)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.BrandId)
            .OnDelete(DeleteBehavior.Restrict);

        // Total Participation: Product MUST belong to a Category
        builder.HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Indexes
        builder.HasIndex(x => x.BrandId);
        builder.HasIndex(x => x.CategoryId);
        builder.HasIndex(x => x.Status);

        builder.HasIndex(x => x.Slug)
            .IsUnique();

        // Composite index for product filtering
        builder.HasIndex(x => new { x.CategoryId, x.BrandId, x.Status });

        // Constraints
        builder.ToTable(t =>
        {
            t.HasCheckConstraint(
                "chk_product_name_not_empty",
                "TRIM(Name) <> ''");

            t.HasCheckConstraint(
                "chk_product_slug_not_empty",
                "Slug IS NULL OR TRIM(Slug) <> ''");
        });
    }
}
