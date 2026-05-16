namespace STRYKE.DAL.Repository.Implementation.SpecificRepository;

public class ReviewRepository : GenericRepository<Review>, IReviewRepository
{
    public ReviewRepository(ApplicationDbContext context) : base(context)
    {
    }
}
