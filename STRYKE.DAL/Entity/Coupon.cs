namespace STRYKE.DAL.Entity;

public class Coupon : BaseEntity
{
    public int CouponId { get; set; }
    public string? Code { get; set; }
    public decimal DiscountValue { get; set; }
    public CouponType CouponType { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool IsActive { get; set; }
    public ICollection<Order> Orders { get; set; } = null!;
}
