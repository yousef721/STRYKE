namespace STRYKE.DAL.Entity;

public class ProductVariant
{
    public int VariantId { get; set; }

    public int ProductId { get; set; }
    public int SizeId { get; set; }
    public int ColorId { get; set; }

    public string SKU { get; set; }
    public int StockQuantity { get; set; }

    public Product Product { get; set; }
    public Size Size { get; set; }
    public Color Color { get; set; }
}
