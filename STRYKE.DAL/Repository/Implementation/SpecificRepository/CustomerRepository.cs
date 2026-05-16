namespace STRYKE.DAL.Repository.Implementation.SpecificRepository;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext context) : base(context)
    {
    }
}
