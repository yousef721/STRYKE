namespace STRYKE.DAL.Repository.Implementation.SpecificRepository;

public class BrandRepository : GenericRepository<Brand>, IBrandRepository
{
    public BrandRepository(ApplicationDbContext context) : base(context)
    {
    }
}
