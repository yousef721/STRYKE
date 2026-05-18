namespace STRYKE.BLL.Services.Interface;

public interface IProductServices
{
    Task<ResponseResult<List<ProductHomeDto>>> GetNewProductsAsync(int count);
}
