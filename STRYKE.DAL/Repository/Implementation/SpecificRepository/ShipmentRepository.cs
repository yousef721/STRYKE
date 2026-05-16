namespace STRYKE.DAL.Repository.Implementation.SpecificRepository;

public class ShipmentRepository : GenericRepository<Shipment>, IShipmentRepository
{
    public ShipmentRepository(ApplicationDbContext context) : base(context)
    {
    }
}
