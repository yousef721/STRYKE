namespace STRYKE.BLL.Services.Interface;

public interface ICategoryServices
{
    Task<IEnumerable<Category>> GetTopCategoriesAsync(int count = 3);
}
