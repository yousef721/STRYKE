namespace STRYKE.DAL.Repository.Implementation.SpecificRepository;

public class SizeRepository : GenericRepository<Size>, ISizeRepository
{
    public SizeRepository(ApplicationDbContext context) : base(context)
    {
    }
}
