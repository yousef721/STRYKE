namespace STRYKE.DAL.Repository.Implementation.GenericRepository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    // QUERY BUILDER
    protected IQueryable<T> BuildQuery(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null,
        bool tracked = false)
    {
        IQueryable<T> query = _dbSet;

        if (!tracked)
            query = query.AsNoTracking();

        if (filter != null)
            query = query.Where(filter);

        if (include != null)
            query = include(query);

        return query;
    }

    // GET ALL
    public async Task<List<T>> GetAllAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null,
        int? skip = null,
        int? take = null,
        bool tracked = false,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(filter, include, tracked);

        if (skip.HasValue)
            query = query.Skip(skip.Value);

        if (take.HasValue)
            query = query.Take(take.Value);

        return await query.ToListAsync(cancellationToken);
    }

    // GET ONE
    public async Task<T?> GetOneAsync(
        Expression<Func<T, bool>> filter,
        Func<IQueryable<T>, IQueryable<T>>? include = null,
        bool tracked = false,
        CancellationToken cancellationToken = default)
    {
        return await BuildQuery(filter, include, tracked)
            .FirstOrDefaultAsync(cancellationToken);
    }

    // GET BY ID
    public async Task<T?> GetByIdAsync(
        object id,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync([id], cancellationToken);
    }

    // PAGINATION
    public async Task<PagedResult<T>> GetPagedAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null,
        CancellationToken cancellationToken = default)
    {
        pageNumber = Math.Max(pageNumber, 1);
        pageSize = Math.Max(pageSize, 1);

        var query = BuildQuery(filter, include);

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<T>(
            items,
            totalCount,
            pageNumber,
            pageSize);
    }

    // ADD
    public async Task AddAsync(
        T entity,
        CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public async Task AddRangeAsync(
        IEnumerable<T> entities,
        CancellationToken cancellationToken = default)
    {
        await _dbSet.AddRangeAsync(entities, cancellationToken);
    }

    // UPDATE
    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    // DELETE
    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    // EXISTS
    public async Task<bool> AnyAsync(
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(filter, cancellationToken);
    }

    // COUNT
    public async Task<int> CountAsync(
        Expression<Func<T, bool>>? filter = null,
        CancellationToken cancellationToken = default)
    {
        if (filter == null)
            return await _dbSet.CountAsync(cancellationToken);

        return await _dbSet.CountAsync(filter, cancellationToken);
    }
}