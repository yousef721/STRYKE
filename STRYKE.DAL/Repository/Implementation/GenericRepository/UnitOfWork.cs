namespace STRYKE.DAL.Repository.Implementation.GenericRepository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IAddressRepository AddressRepository {get; private set; }
    public IBrandRepository BrandRepository {get; private set; }
    public ICartRepository CartRepository {get; private set; }
    public ICartItemRepository CartItemRepository {get; private set; }
    public ICategoryRepository CategoryRepository {get; private set; }
    public IColorRepository ColorRepository {get; private set; }
    public ICouponRepository CouponRepository {get; private set; }
    public ICustomerRepository CustomerRepository {get; private set; }
    public IOrderRepository OrderRepository {get; private set; }
    public IOrderItemRepository OrderItemRepository {get; private set; }
    public IPaymentRepository PaymentRepository {get; private set; }
    public IProductRepository ProductRepository {get; private set; }
    public IProductImageRepository ProductImageRepository {get; private set; }
    public IProductVariantRepository ProductVariantRepository {get; private set; }
    public IReviewRepository ReviewRepository {get; private set; }
    public IShipmentRepository ShipmentRepository {get; private set; }
    public ISizeRepository SizeRepository {get; private set; }
    public IWishlistRepository WishlistRepository {get; private set; }
    public IWishlistItemRepository WishlistItemRepository {get; private set; }
    
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        AddressRepository = new AddressRepository(context);
        BrandRepository = new BrandRepository(context);
        CartRepository = new CartRepository(context);
        CartItemRepository = new CartItemRepository(context);
        CategoryRepository = new CategoryRepository(context);
        ColorRepository = new ColorRepository(context);
        CouponRepository = new CouponRepository(context);
        CustomerRepository = new CustomerRepository(context);
        OrderRepository = new OrderRepository(context);
        OrderItemRepository = new OrderItemRepository(context);
        PaymentRepository = new PaymentRepository(context);
        ProductRepository = new ProductRepository(context);
        ProductImageRepository = new ProductImageRepository(context);
        ProductVariantRepository = new ProductVariantRepository(context);
        ReviewRepository = new ReviewRepository(context);
        ShipmentRepository = new ShipmentRepository(context);
        SizeRepository = new SizeRepository(context);
        WishlistRepository = new WishlistRepository(context);
        WishlistItemRepository = new WishlistItemRepository(context);
    }
    public async Task<int> CompleteAsync()
    {
       return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
