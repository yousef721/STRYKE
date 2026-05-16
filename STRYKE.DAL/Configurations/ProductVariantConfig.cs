namespace STRYKE.DAL.Configurations;

public class ProductVariantConfig : IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(EntityTypeBuilder<ProductVariant> builder)
    {
        builder.HasKey(x => x.VariantId);

        // Properties

        // Total Participation: Variant MUST belong to a Product
        builder.Property(x => x.ProductId)
            .IsRequired();
 
        // Total Participation: Variant MUST have a Size
        builder.Property(x => x.SizeId)
            .IsRequired();
 
        // Total Participation: Variant MUST have a Color
        builder.Property(x => x.ColorId)
            .IsRequired();

        builder.Property(x => x.SKU)
            .HasMaxLength(100);

        builder.Property(x => x.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.DiscountPrice)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.StockQuantity)
            .IsRequired();
        
        // Relations
        // Total Participation: Variant must belong to a Product
        builder.HasOne(x => x.Product)
            .WithMany(x => x.Variants)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        // Total Participation: Variant must have a Size
        builder.HasOne(x => x.Size)
            .WithMany(x => x.ProductVariants)
            .HasForeignKey(x => x.SizeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Total Participation: Variant must have a Color
        builder.HasOne(x => x.Color)
            .WithMany(x => x.ProductVariants)
            .HasForeignKey(x => x.ColorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(x => x.ProductId);
        builder.HasIndex(x => x.SizeId);
        builder.HasIndex(x => x.ColorId);
        builder.HasIndex(x => x.StockQuantity);

        builder.HasIndex(x => x.SKU)
            .IsUnique();

        // Composite unique: Only one variant per product+size+color combination
        builder.HasIndex(x => new { x.ProductId, x.SizeId, x.ColorId })
            .IsUnique()
            .HasDatabaseName("UK_ProductVariant_Product_Size_Color");

        // Constraints
        builder.ToTable(t =>
        {
            t.HasCheckConstraint(
                "chk_productVariant_price",
                "Price >= 0");

            t.HasCheckConstraint(
                "chk_productVariant_discount_price",
                "DiscountPrice IS NULL OR (DiscountPrice > 0 AND DiscountPrice < Price)");

            t.HasCheckConstraint(
                "chk_productVariant_stock_quantity",
                "StockQuantity >= 0");

            t.HasCheckConstraint(
                "chk_productVariant_sku_not_empty",
                "SKU IS NULL OR TRIM(SKU) <> ''");
        });

    }
}
