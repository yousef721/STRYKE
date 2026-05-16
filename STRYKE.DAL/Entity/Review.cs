namespace STRYKE.DAL.Entity;

public class Review : BaseEntity
{
    public int ReviewId { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public Customer Customer { get; set; } = null!;
    public Product Product { get; set; } = null!;
}
