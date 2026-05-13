namespace STRYKE.DAL.Entity;

public class Category : BaseEntity
{
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Image { get; set; }
    public ICollection<Product> Products { get; set; } = null!;
}
