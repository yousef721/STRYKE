using System;

namespace STRYKE.DAL.Entity;

public class Payment
{
    public int PaymentId { get; set; }

    public int OrderId { get; set; }

    public string Provider { get; set; }
    public string Method { get; set; }

    public decimal Amount { get; set; }

    public string Status { get; set; }

    public DateTime PaidAt { get; set; }

    public Order Order { get; set; }
}
