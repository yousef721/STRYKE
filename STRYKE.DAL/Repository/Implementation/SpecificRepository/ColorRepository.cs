namespace STRYKE.DAL.Repository.Implementation.SpecificRepository;

public class ColorRepository : GenericRepository<Color>, IColorRepository
{
    public ColorRepository(ApplicationDbContext context) : base(context)
    {
    }
}
