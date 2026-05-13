namespace STRYKE.DAL.Entity;

public class Wishlist : BaseEntity
{
    public int WishlistId { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public ICollection<WishlistItem> WishlistItems { get; set; } = null!;
}
