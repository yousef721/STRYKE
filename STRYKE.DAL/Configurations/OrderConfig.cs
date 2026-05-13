namespace STRYKE.DAL.Configurations;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.OrderId);

        // Properties
        builder.Property(x => x.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.TotalAmount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        // Indexes (important for performance)
        builder.HasIndex(x => x.CustomerId);
        builder.HasIndex(x => x.AddressId);
        builder.HasIndex(x => x.CouponId);
        builder.HasIndex(x => x.Status);

        // Relations
        builder.HasOne(x => x.Address)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.AddressId)
            .OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(x => x.Coupon)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.CouponId)
            .OnDelete(DeleteBehavior.SetNull);


        builder.HasMany(x => x.OrderItems)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.HasOne(x => x.Payment)
            .WithOne(x => x.Order)
            .HasForeignKey<Payment>(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
