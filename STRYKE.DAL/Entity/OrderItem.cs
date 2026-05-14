namespace STRYKE.DAL.Entity;

public class OrderItem : BaseEntity
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public int ProductVariantId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Order Order { get; set; } = null!;
    public ProductVariant ProductVariant { get; set; } = null!;
}
