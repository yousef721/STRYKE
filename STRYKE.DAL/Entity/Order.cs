namespace STRYKE.DAL.Entity;

public class Order : BaseEntity
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public int AddressId { get; set; }
    public int? CouponId { get; set; }
    public OrderStatus Status { get; set; }
    public decimal TotalAmount { get; set; }
    public Coupon Coupon { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public ICollection<OrderItem> OrderItems { get; set; } = null!;
    public Payment Payment { get; set; } = null!;
}
