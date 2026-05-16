namespace STRYKE.DAL.Repository.Interface;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);

    Task<List<T>> GetAllAsync(
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>[]? includeProps = null,
        bool tracked = true);

    Task<T?> GetOneAsync(
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>[]? includeProps = null,
        bool tracked = true);


    Task<T> AddAsync(T entity);

    void Update(T entity);

    void Delete(T entity);
}
