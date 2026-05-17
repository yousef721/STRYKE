namespace STRYKE.BLL.Services.Implementation;

public class ProductServices : IProductServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductServices(IUnitOfWork unitOfWork, IMapper mapper){
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ResponseResult<ProductHomeDto>> GetNewProducts()
    {
        var products = await _unitOfWork.ProductRepository.GetNewProducts(p => p.Include(p => p.Variants).Include(p => p.Images));

        if (products == null || !products.Any())
            return ResponseResult<ProductHomeDto>.NotFound("No products found");

        var productsVM = _mapper.Map<ProductHomeDto>(products);

        return ResponseResult<ProductHomeDto>.Success(productsVM);
    }
}
