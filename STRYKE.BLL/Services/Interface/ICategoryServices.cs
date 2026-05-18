namespace STRYKE.BLL.Services.Interface;

public interface ICategoryServices
{
    Task<ResponseResult<List<CategoryHomeDto>>>   GetTopHomeCategoriesAsync(int count);
}
