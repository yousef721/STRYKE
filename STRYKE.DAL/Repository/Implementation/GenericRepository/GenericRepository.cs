namespace STRYKE.DAL.Repository.Implementation.GenericRepository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    protected IQueryable<T> BuildQuery(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null,
        bool tracked = true)
    {
        IQueryable<T> query = _dbSet;

        // Filter
        if (filter != null)
            query = query.Where(filter);

        // Include
        if (include != null)
            query = include(query);

        // Tracking
        if (!tracked)
            query = query.AsNoTracking();

        return query;
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null,
        bool tracked = true)
    {
        return await BuildQuery(filter, include, tracked)
            .ToListAsync();
    }

    public async Task<T?> GetOneAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null,
        bool tracked = true)
    {
        return await BuildQuery(filter, include, tracked)
            .FirstOrDefaultAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}