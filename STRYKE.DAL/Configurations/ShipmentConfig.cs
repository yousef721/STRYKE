namespace STRYKE.DAL.Configurations;

public class ShipmentConfig : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder.HasKey(x => x.ShipmentId);

        // Properties
        builder.Property(x => x.TrackingNumber)
            .HasMaxLength(150);

        builder.Property(x => x.Carrier)
            .HasMaxLength(150);

        builder.Property(x => x.ShippingStatus)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.EstimatedDelivery)
            .IsRequired(false);

        // Relations
        builder.HasOne(x => x.Order)
            .WithOne(x => x.Shipment)
            .HasForeignKey<Shipment>(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Indexes
        builder.HasIndex(x => x.OrderId)
            .IsUnique();
    }
}