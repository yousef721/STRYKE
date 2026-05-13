namespace STRYKE.DAL.Configurations;

public class ProductVariantConfig : IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(EntityTypeBuilder<ProductVariant> builder)
    {
        builder.HasKey(x => x.VariantId);

        // Properties
        builder.Property(x => x.SKU)
            .HasMaxLength(100);

        builder.Property(x => x.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.DiscountPrice)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.StockQuantity)
            .IsRequired();

        // Indexes (important for performance)
        builder.HasIndex(x => x.ProductId);
        builder.HasIndex(x => x.SizeId);
        builder.HasIndex(x => x.ColorId);
        builder.HasIndex(x => x.SKU)
            .IsUnique();

        // Relations
        builder.HasOne(x => x.Size)
            .WithMany(x => x.ProductVariants)
            .HasForeignKey(x => x.SizeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Color)
            .WithMany(x => x.ProductVariants)
            .HasForeignKey(x => x.ColorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Business Rule
        builder.HasIndex(x => new { x.ProductId, x.SizeId, x.ColorId })
            .IsUnique();
    }
}
