namespace STRYKE.DAL.Entity;

public class Category : BaseEntity
{
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public string Slug { get; set; } = null!;
    public bool ShowInHomePage { get; set; }
    public ICollection<Product> Products { get; set; } = null!;
}
