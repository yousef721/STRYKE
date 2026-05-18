namespace STRYKE.DAL.Repository.Interfaces.GenericRepository;

public interface IGenericRepository<T>
    where T : class
{
    // GET ALL
    Task<List<T>> GetAllAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null,
        int? skip = null,
        int? take = null,
        bool tracked = false,
        CancellationToken cancellationToken = default);

    // GET ONE
    Task<T?> GetOneAsync(
        Expression<Func<T, bool>> filter,
        Func<IQueryable<T>, IQueryable<T>>? include = null,
        bool tracked = false,
        CancellationToken cancellationToken = default);

    // GET BY ID
    Task<T?> GetByIdAsync(
        object id,
        CancellationToken cancellationToken = default);

    // PAGINATION
    Task<PagedResult<T>> GetPagedAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null,
        CancellationToken cancellationToken = default);

    // ADD
    Task AddAsync(
        T entity,
        CancellationToken cancellationToken = default);

    Task AddRangeAsync(
        IEnumerable<T> entities,
        CancellationToken cancellationToken = default);

    // UPDATE
    void Update(T entity);

    // DELETE
    void Delete(T entity);

    // EXISTS
    Task<bool> AnyAsync(
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default);

    // COUNT
    Task<int> CountAsync(
        Expression<Func<T, bool>>? filter = null,
        CancellationToken cancellationToken = default);
}