namespace STRYKE.DAL.Entity;

public class Shipment : BaseEntity
{
    public int ShipmentId { get; set; }
    public int OrderId { get; set; }
    public string? TrackingNumber { get; set; }
    public string? Carrier { get; set; }
    public ShippingStatus ShippingStatus { get; set; }
    public DateTime? EstimatedDelivery { get; set; } // Null until shipped
    public Order Order { get; set; } = null!;
}
