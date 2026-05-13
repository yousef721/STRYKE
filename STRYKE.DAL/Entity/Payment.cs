namespace STRYKE.DAL.Entity;

public class Payment : BaseEntity
{
    public int PaymentId { get; set; }
    public int OrderId { get; set; }
    public string? Provider { get; set; }
    public PaymentMethod Method { get; set; }
    public decimal Amount { get; set; }
    public PaymentStatus Status { get; set; }
    public DateTime PaidAt { get; set; }
    public Order Order { get; set; } = null!;
}
