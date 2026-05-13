namespace STRYKE.DAL.Entity;

public class CartItem : BaseEntity
{
    public int CartItemId { get; set; }
    public int CartId { get; set; }
    public int ProductVariantId { get; set; }
    public int Quantity { get; set; }
    public Cart Cart { get; set; } = null!;
    public ProductVariant Variant { get; set; } = null!;
}
