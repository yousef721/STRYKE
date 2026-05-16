namespace STRYKE.DAL.Configurations;

public class ShipmentConfig : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder.HasKey(x => x.ShipmentId);

        // Properties
        // Total Participation: Shipment MUST belong to an Order
        builder.Property(x => x.OrderId)
            .IsRequired();

        builder.Property(x => x.TrackingNumber)
            .HasMaxLength(150);

        builder.Property(x => x.Carrier)
            .HasMaxLength(150);

        builder.Property(x => x.ShippingStatus)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.EstimatedDelivery)
            .IsRequired(false); // Null until shipped

        // Relations
        // Total Participation: Shipment must belong to an Order (one-to-one)
        builder.HasOne(x => x.Order)
            .WithOne(x => x.Shipment)
            .HasForeignKey<Shipment>(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Indexes
        builder.HasIndex(x => x.ShippingStatus);
        builder.HasIndex(x => x.TrackingNumber);

        // One shipment per order (unique)
        builder.HasIndex(x => x.OrderId)
            .IsUnique();

        // Composite index for shipment tracking
        builder.HasIndex(x => new { x.TrackingNumber, x.Carrier });

        // Constraints
        builder.ToTable(t =>
        {
            // Tracking number cannot be empty (if provided)
            t.HasCheckConstraint(
                "chk_shipment_tracking_not_empty",
                "TrackingNumber IS NULL OR TRIM(TrackingNumber) <> ''");

            // Carrier cannot be empty (if provided)
            t.HasCheckConstraint(
                "chk_shipment_carrier_not_empty",
                "Carrier IS NULL OR TRIM(Carrier) <> ''");
                
            // EstimatedDelivery must be after shipment creation
            t.HasCheckConstraint(
                "chk_shipment_estimated_delivery_not_null",
                "EstimatedDelivery IS NULL OR EstimatedDelivery >= CreatedAt");
        });
    }
}