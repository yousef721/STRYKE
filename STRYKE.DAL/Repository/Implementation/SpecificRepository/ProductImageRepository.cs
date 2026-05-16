namespace STRYKE.DAL.Repository.Implementation.SpecificRepository;

public class ProductImageRepository : GenericRepository<ProductImage>, IProductImageRepository
{
    public ProductImageRepository(ApplicationDbContext context) : base(context)
    {
    }
}
