namespace STRYKE.DAL.Configurations;

public class CouponConfig : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.HasKey(x => x.CouponId);

        // Properties
        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.DiscountValue)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.CouponType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.ExpiryDate)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        // Indexes
        builder.HasIndex(x => x.IsActive);
        builder.HasIndex(x => x.ExpiryDate);

        builder.HasIndex(x => x.Code)
            .IsUnique();

        // Constraints
        builder.ToTable(t =>
        {
            // Discount must be between 0 and 100
            t.HasCheckConstraint(
                "chk_coupon_discount_value",
                "DiscountValue > 0 AND DiscountValue <= 100");

            // Expiry date must exist
            t.HasCheckConstraint(
                "chk_coupon_expiry_not_null",
                "ExpiryDate IS NOT NULL");
        });
    }
} 