namespace STRYKE.DAL.Repository.Implementation.SpecificRepository;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
