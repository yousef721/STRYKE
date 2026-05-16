namespace STRYKE.DAL.Repository.Implementation.SpecificRepository;

public class CouponRepository : GenericRepository<Coupon>, ICouponRepository
{
    public CouponRepository(ApplicationDbContext context) : base(context)
    {
    }
}
