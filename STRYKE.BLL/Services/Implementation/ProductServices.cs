
namespace STRYKE.BLL.Services.Implementation;

public class ProductServices : IProductServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductServices(IUnitOfWork unitOfWork, IMapper mapper){
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ResponseResult<List<ProductHomeDto>>> GetNewProductsAsync(int count = 8)
    {
        var products = await _unitOfWork.ProductRepository.GetNewProductsAsync(count, include: p => p.Include(p => p.Images).Include(p => p.Variants));

        if (products == null || !products.Any())
            return ResponseResult<List<ProductHomeDto>>.NotFound("No products found");

        var productsDto = _mapper.Map<List<ProductHomeDto>>(products);

        return ResponseResult<List<ProductHomeDto>>.Success(productsDto);
    }
}
