namespace STRYKE.DAL.Repository.Implementation.SpecificRepository;

public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
{
    public CartItemRepository(ApplicationDbContext context) : base(context)
    {
    }
}
