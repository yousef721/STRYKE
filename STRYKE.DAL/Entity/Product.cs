namespace STRYKE.DAL.Entity;

public class Product : BaseEntity
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public ProductStatus Status { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
    public Brand Brand { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public ICollection<ProductVariant> Variants { get; set; } = null!;
    public ICollection<ProductImage> Images { get; set; } = null!;
    public ICollection<Review> Reviews { get; set; } = null!;
    public ICollection<WishlistItem> WishlistItems { get; set; } = null!;
}
