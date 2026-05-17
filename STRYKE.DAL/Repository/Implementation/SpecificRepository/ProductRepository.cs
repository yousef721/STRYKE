
namespace STRYKE.DAL.Repository.Implementation.SpecificRepository;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<Product>> GetNewProducts(Func<IQueryable<Product>, IQueryable<Product>>? include = null, int count = 8)
    {
        return await BuildQuery(
                include: include,
                tracked: false
            )
            .OrderByDescending(p => p.CreatedAt)
            .Take(count)
            .ToListAsync();    
    }
}
