namespace STRYKE.DAL.Configurations;

public class ProductImageConfig : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.HasKey(x => x.ImageId);

        // Properties
        builder.Property(x => x.ImageUrl)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.IsPrimary)
            .HasDefaultValue(false);

        // Indexes (important for performance)
        builder.HasIndex(x => x.ProductId);
    }
}
