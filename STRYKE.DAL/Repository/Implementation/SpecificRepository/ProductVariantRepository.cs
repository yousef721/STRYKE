namespace STRYKE.DAL.Repository.Implementation.SpecificRepository;

public class ProductVariantRepository : GenericRepository<ProductVariant>, IProductVariantRepository
{
    public ProductVariantRepository(ApplicationDbContext context) : base(context)
    {
    }
}
