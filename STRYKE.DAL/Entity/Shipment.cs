using System;

namespace STRYKE.DAL.Entity;

public class Shipment
{
    public int ShipmentId { get; set; }

    public int OrderId { get; set; }

    public string TrackingNumber { get; set; }

    public string Carrier { get; set; }

    public string ShippingStatus { get; set; }

    public DateTime EstimatedDelivery { get; set; }

    public Order Order { get; set; }
}
