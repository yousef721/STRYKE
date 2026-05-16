namespace STRYKE.DAL.Repository.Implementation.SpecificRepository;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }
}
