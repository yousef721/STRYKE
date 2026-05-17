namespace STRYKE.DAL.Repository.Interface.GenericRepository;

public interface IUnitOfWork : IDisposable
{
    IAddressRepository AddressRepository { get; }
    IBrandRepository BrandRepository { get; }
    ICartRepository CartRepository { get; }
    ICartItemRepository CartItemRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IColorRepository ColorRepository { get; }
    ICouponRepository CouponRepository { get; }
    ICustomerRepository CustomerRepository { get; }
    IOrderRepository OrderRepository { get; }
    IOrderItemRepository OrderItemRepository { get; }
    IPaymentRepository PaymentRepository { get; }
    IProductRepository ProductRepository { get; }
    IProductImageRepository ProductImageRepository { get; }
    IProductVariantRepository ProductVariantRepository { get; }
    IReviewRepository ReviewRepository { get; }
    IShipmentRepository ShipmentRepository { get; }
    ISizeRepository SizeRepository { get; }
    IWishlistRepository WishlistRepository { get; }
    IWishlistItemRepository WishlistItemRepository { get; }
    Task<int> CompleteAsync();
}
