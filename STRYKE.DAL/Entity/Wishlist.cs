using System;

namespace STRYKE.DAL.Entity;

public class Wishlist
{
    public int WishlistId { get; set; }

    public int CustomerId { get; set; }

    public Customer Customer { get; set; }

    public ICollection<WishlistItem> WishlistItems { get; set; }
}
