
namespace STRYKE.BLL.Services.Implementation;

public class CategoryServices : ICategoryServices
{
    public CategoryServices()
    {
        
    }

    public Task<IEnumerable<Category>> GetTopCategoriesAsync(int count = 3)
    {
        throw new NotImplementedException();
    }
}
