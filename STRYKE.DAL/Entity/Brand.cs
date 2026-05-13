namespace STRYKE.DAL.Entity;

public class Brand : BaseEntity
{
    public int BrandId { get; set; }
    public string? Name { get; set; }
    public string? Logo { get; set; }
    public ICollection<Product> Products { get; set; } = null!;
}
