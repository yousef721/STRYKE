namespace STRYKE.DAL.Entity;

public class ProductVariant : BaseEntity
{
    public int VariantId { get; set; }
    public int ProductId { get; set; }
    public int SizeId { get; set; }
    public int ColorId { get; set; }
    public string? SKU { get; set; }
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public int StockQuantity { get; set; }
    public Product Product { get; set; } = null!;
    public Size Size { get; set; } = null!;
    public Color Color { get; set; } = null!;
    public ICollection<OrderItem> OrderItems = null!;
    public ICollection<CartItem> CartItems = null!;
}