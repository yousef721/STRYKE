namespace STRYKE.DAL.Repository.Implementation.SpecificRepository;

public class AddressRepository : GenericRepository<Address>, IAddressRepository
{
    public AddressRepository(ApplicationDbContext context) : base(context)
    {
    }
}
