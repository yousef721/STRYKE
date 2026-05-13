using System;

namespace STRYKE.DAL.Entity;

public class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }

    public decimal Price { get; set; }
    public decimal DiscountPrice { get; set; }

    public string MainImage { get; set; }

    public int BrandId { get; set; }
    public int CategoryId { get; set; }

    public Brand Brand { get; set; }
    public Category Category { get; set; }

    public ICollection<ProductVariant> Variants { get; set; }
    public ICollection<ProductImage> Images { get; set; }
    public ICollection<Review> Reviews { get; set; }
}
