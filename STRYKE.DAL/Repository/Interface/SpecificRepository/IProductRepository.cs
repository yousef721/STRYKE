namespace STRYKE.DAL.Repository.Interface.SpecificRepository;

public interface IProductRepository : IGenericRepository<Product>
{
    public Task<IEnumerable<Product>> GetNewProductsAsync(int count, Func<IQueryable<Product>, IQueryable<Product>>? include = null, bool tracked = false);
}
