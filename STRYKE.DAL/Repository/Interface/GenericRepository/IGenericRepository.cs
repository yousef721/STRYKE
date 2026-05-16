namespace STRYKE.DAL.Repository.Interface;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);

    Task<IReadOnlyList<T>> GetAllAsync();

    Task<T> AddAsync(T entity);

    void Update(T entity);

    void Delete(T entity);
}
