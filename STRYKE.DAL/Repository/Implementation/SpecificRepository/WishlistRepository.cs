namespace STRYKE.DAL.Repository.Implementation.SpecificRepository;

public class WishlistRepository : GenericRepository<Wishlist>, IWishlistRepository
{
    public WishlistRepository(ApplicationDbContext context) : base(context)
    {
    }
}
