namespace STRYKE.DAL.Entity;

public class Color : BaseEntity
{
    public int ColorId { get; set; }
    public string? Name { get; set; }
    public string? HexCode { get; set; }
    public ICollection<ProductVariant> ProductVariants { get; set; } = null!;
}
