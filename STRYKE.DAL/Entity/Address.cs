namespace STRYKE.DAL.Entity;

public class Address
{
    public int AddressId { get; set; }
    public int CustomerId { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Building { get; set; }
    public Customer Customer { get; set; }
}
