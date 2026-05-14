using System;

namespace STRYKE.DAL.Configurations;

public class CartItemConfig : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(x => x.CartItemId);

        // Properties
        builder.Property(x => x.Quantity)
            .IsRequired();

        // Relations
        builder.HasOne(x => x.Cart)
            .WithMany(x => x.CartItems)
            .HasForeignKey(x => x.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Variant)
            .WithMany(x => x.CartItems)
            .HasForeignKey(x => x.ProductVariantId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(x => x.CartId);
        builder.HasIndex(x => x.ProductVariantId);
        builder.HasIndex(x => new { x.CartId, x.ProductVariantId })
            .IsUnique();
    }

}
