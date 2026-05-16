namespace STRYKE.DAL.Repository.Implementation.SpecificRepository;

public class WishlistItemRepository : GenericRepository<WishlistItem>, IWishlistItemRepository
{
    public WishlistItemRepository(ApplicationDbContext context) : base(context)
    {
    }
}
