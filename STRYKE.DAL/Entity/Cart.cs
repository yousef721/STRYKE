using System;

namespace STRYKE.DAL.Entity;

public class Cart
{
    public int CartId { get; set; }
    public int CustomerId { get; set; }

    public Customer Customer { get; set; }

    public ICollection<CartItem> CartItems { get; set; }
}
