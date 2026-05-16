namespace STRYKE.DAL.Repository.Implementation.SpecificRepository;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext context) : base(context)
    {
    }
}
