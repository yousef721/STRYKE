namespace STRYKE.DAL.Repository.Implementation.SpecificRepository;

public class CartRepository : GenericRepository<Cart>, ICartRepository
{
    public CartRepository(ApplicationDbContext context) : base(context)
    {
    }
}
