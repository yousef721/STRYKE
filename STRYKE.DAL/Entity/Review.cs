using System;

namespace STRYKE.DAL.Entity;

public class Review
{
    public int ReviewId { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public Customer Customer { get; set; }
    public Product Product { get; set; }
}
