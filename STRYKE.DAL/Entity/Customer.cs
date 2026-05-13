namespace STRYKE.DAL.Entity;

public class Customer : BaseEntity
{
    public int CustomerId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? PhoneNumber { get; set; }
    public Gender Gender { get; set; }
    public bool IsActive { get; set; }
    public ICollection<Address> Addresses { get; set; } = null!;
    public ICollection<Order> Orders { get; set; } = null!;
    public ICollection<Review> Reviews { get; set; } = null!;
    public Wishlist Wishlist { get; set; } = null!;
    public Cart Cart { get; set; } = null!;
}
