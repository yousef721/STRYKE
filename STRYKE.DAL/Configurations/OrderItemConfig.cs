using System;

namespace STRYKE.DAL.Configurations;

public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(x => x.OrderItemId);

        // Properties
        builder.Property(x => x.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.Quantity)
            .IsRequired();

        // Relation
        // Total Participation: OrderItem must belong to an Order
        builder.HasOne(x => x.Order)
            .WithMany(x => x.OrderItems)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

       // Total Participation: OrderItem must reference a ProductVariant
        builder.HasOne(x => x.ProductVariant)
            .WithMany(x => x.OrderItems)
            .HasForeignKey(x => x.ProductVariantId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent deleting variant if ordered
            
        //Index
        builder.HasIndex(x => x.OrderId);
        builder.HasIndex(x => x.ProductVariantId);

        // Composite index for order item lookups
        builder.HasIndex(x => new { x.OrderId, x.ProductVariantId });
        
        // Constraints
        builder.ToTable(t =>
        {
            // Price must be positive
            t.HasCheckConstraint(
                "chk_orderItem_price",
                "Price >= 0");

            // Quantity must be positive
            t.HasCheckConstraint(
                "chk_orderItem_quantity",
                "Quantity > 0");
        });
    }
}
