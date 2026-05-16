namespace STRYKE.DAL.Configurations;

public class ProductImageConfig : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.HasKey(x => x.ImageId);

        // Properties

        // Total Participation: Image MUST belong to a Product
        builder.Property(x => x.ProductId)
            .IsRequired();

        builder.Property(x => x.ImageUrl)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.IsPrimary)
            .HasDefaultValue(false);

        // Relations

        // Total Participation: Image must belong to a Product
        builder.HasOne(x => x.Product)
            .WithMany(x => x.Images)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(x => x.ProductId);

        // Index for finding primary image
        builder.HasIndex(x => new { x.ProductId, x.IsPrimary });

        builder.ToTable(t =>
        {
            t.HasCheckConstraint(
                "chk_productImage_url_not_empty",
                "TRIM(ImageUrl) <> ''");
        });
    }
}
