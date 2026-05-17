namespace STRYKE.DAL.Repository.Interface.SpecificRepository;

public interface IProductRepository : IGenericRepository<Product>
{
    public Task<List<Product>> GetNewProducts(Func<IQueryable<Product>, IQueryable<Product>>? include = null, int count = 8);
}
