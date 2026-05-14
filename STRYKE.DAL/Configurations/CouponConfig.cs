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
        builder.HasIndex(x => x.Code)
            .IsUnique();
    }
} 