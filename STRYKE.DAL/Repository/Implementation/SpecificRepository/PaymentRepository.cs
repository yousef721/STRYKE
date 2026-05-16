namespace STRYKE.DAL.Repository.Implementation.SpecificRepository;

public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
{
    public PaymentRepository(ApplicationDbContext context) : base(context)
    {
    }
}
