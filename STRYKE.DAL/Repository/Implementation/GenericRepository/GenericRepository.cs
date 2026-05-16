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

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
    public async Task<List<T>> GetAllAsync(
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>[]? includeProps = null,
        bool tracked = true)
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
            query = query.Where(filter);

        if (includeProps != null)
        {
            foreach (var prop in includeProps)
                query = query.Include(prop);
        }

        if (!tracked)
            query = query.AsNoTracking();

        return await query.ToListAsync();
    }

    public async Task<T?> GetOneAsync(
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>[]? includeProps = null,
        bool tracked = true)
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
            query = query.Where(filter);

        if (includeProps != null)
        {
            foreach (var prop in includeProps)
                query = query.Include(prop);
        }

        if (!tracked)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync();
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

    public Task<IReadOnlyList<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
