using System;

namespace STRYKE.DAL.Entity;

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public int AddressId { get; set; }
    public string Status { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public Customer Customer { get; set; }
    public Address Address { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
    public Payment Payment { get; set; }
}
