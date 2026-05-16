namespace STRYKE.DAL.Configurations;

public class PaymentConfig : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(x => x.PaymentId);


        // Properties
        // Total Participation: Payment MUST belong to an Order
        builder.Property(x => x.OrderId)
            .IsRequired();

        builder.Property(x => x.Provider)
            .HasMaxLength(150);

        builder.Property(x => x.Method)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.Amount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.PaidAt)
            .IsRequired(false);  // Null until payment succeeds
 

        // Relations
        // Total Participation: Payment must belong to an Order (one-to-one)
        builder.HasOne(x => x.Order)
            .WithOne(x => x.Payment)
            .HasForeignKey<Payment>(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(x => x.Status);
        builder.HasIndex(x => x.Method);

        // One payment per order (unique)
        builder.HasIndex(x => x.OrderId)
            .IsUnique();

        // Constraints
        builder.ToTable(t =>
        {
            // Amount must be positive
            t.HasCheckConstraint(
                "chk_payment_amount",
                "Amount >= 0");
                
            // If payment is successful (Status = 1), PaidAt must be set
            t.HasCheckConstraint(
                "chk_payment_paid_at_required",
                "Status <> 1 OR PaidAt IS NOT NULL");

            // PaidAt can only be set for successful payments
            t.HasCheckConstraint(
                "chk_payment_paid_at_only_for_success",
                "PaidAt IS NULL OR Status = 1");
        });
    }
}