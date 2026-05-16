namespace STRYKE.DAL.Configurations;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.OrderId);

        // Properties
        builder.Property(x => x.CustomerId)
        .IsRequired();
 
        builder.Property(x => x.AddressId)
            .IsRequired();
 
        builder.Property(x => x.CouponId)
            .IsRequired(false);  // Partial Participation - optional

        builder.Property(x => x.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.TotalAmount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        // Relation
        // Total Participation: Order MUST belong to a Customer
        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Total Participation: Order MUST have a delivery Address
        builder.HasOne(x => x.Address)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.AddressId)
            .OnDelete(DeleteBehavior.Restrict);

        // Partial Participation: Order MAY use a Coupon
        builder.HasOne(x => x.Coupon)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.CouponId)
            .OnDelete(DeleteBehavior.SetNull);  // Order unaffected if coupon deleted

        // Indexes
        builder.HasIndex(x => x.CustomerId);
        builder.HasIndex(x => x.AddressId);
        builder.HasIndex(x => x.CouponId);
        builder.HasIndex(x => x.Status);

        // Composite index for customer order history
        builder.HasIndex(x => new { x.CustomerId, x.CreatedAt });

        // Constraints
        builder.ToTable(t =>
        {
            t.HasCheckConstraint(
                "chk_order_total_amount",
                "TotalAmount >= 0");
        });
    }
}
