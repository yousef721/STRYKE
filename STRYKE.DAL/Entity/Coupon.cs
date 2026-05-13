using System;

namespace STRYKE.DAL.Entity;

public class Coupon
{
    public int CouponId { get; set; }

    public string Code { get; set; }

    public decimal DiscountValue { get; set; }

    public DateTime ExpirationDate { get; set; }

    public bool IsActive { get; set; }
}
