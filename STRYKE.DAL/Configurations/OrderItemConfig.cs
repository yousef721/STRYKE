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
        
        // Indexes
        builder.HasIndex(x => x.OrderId);
        builder.HasIndex(x => x.VariantId);

        // Relations
        builder.HasOne(x => x.Variant)
            .WithMany(x => x.OrderItems)
            .HasForeignKey(x => x.VariantId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
