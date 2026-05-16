namespace STRYKE.DAL.Repository.Implementation.SpecificRepository;

public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(ApplicationDbContext context) : base(context)
    {
    }
}
