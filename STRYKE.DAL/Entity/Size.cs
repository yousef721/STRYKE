namespace STRYKE.DAL.Entity;

public class Size : BaseEntity
{
    public int SizeId { get; set; }
    public string? Name { get; set; }
    public SizeCategory Category { get; set; }
    public ICollection<ProductVariant> ProductVariants { get; set; } = null!;
}
