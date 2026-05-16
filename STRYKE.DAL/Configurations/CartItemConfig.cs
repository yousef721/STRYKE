namespace STRYKE.DAL.Configurations;

public class CartItemConfig : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(x => x.CartItemId);

        // Properties
        builder.Property(x => x.Quantity)
            .IsRequired();

        // Total Participation: CartItem MUST belong to a Cart
        builder.Property(x => x.CartId)
            .IsRequired();
 
        // Total Participation: CartItem MUST reference a ProductVariant
        builder.Property(x => x.ProductVariantId)
            .IsRequired();

        // Relations
        // Total Participation: CartItem must have a Cart
        builder.HasOne(x => x.Cart)
            .WithMany(x => x.CartItems)
            .HasForeignKey(x => x.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        // Total Participation: CartItem must reference a ProductVariant
        builder.HasOne(x => x.Variant)
            .WithMany(x => x.CartItems)
            .HasForeignKey(x => x.ProductVariantId)
            .OnDelete(DeleteBehavior.Restrict);  // Prevent deleting variant if in cart

        // Indexes
        builder.HasIndex(x => x.CartId);
        builder.HasIndex(x => x.ProductVariantId);
        
        // Composite unique index: One product variant per cart only
        builder.HasIndex(x => new { x.CartId, x.ProductVariantId })
            .IsUnique()
            .HasDatabaseName("UK_CartItem_Cart_Variant");

        // Constraints
        builder.ToTable(t =>
        {
            t.HasCheckConstraint(
                "chk_cartItem_quantity",
                "Quantity >= 0");
        });
    }

}
