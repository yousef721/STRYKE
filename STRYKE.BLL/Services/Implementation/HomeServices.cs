

namespace STRYKE.BLL.Services.Implementation;

public class HomeServices : IHomeServices
{
    private readonly IUnitOfWork _unitOfWork;

    public HomeServices(IUnitOfWork unitOfWork) 
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<HomeVM>> GetHomeDataAsync()
    {
        try {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync(categories => categories.ShowInHomePage == true, tracked: false);
            var products = await _unitOfWork.ProductRepository.GetNewProducts(include: q => q.Include(p => p.Variants).Include(p => p.Images));
            var vm = new HomeVM
            {
                Categories = categories
                    .Take(3)
                    .Select(c => new CategoryHomeVM
                    {
                        Id = c.CategoryId,
                        Name = c.Name!,
                        Slug = c.Slug,
                        Image = c.Image
                    }),
                Products = products.Select(p => new ProductHomeVM
                {
                    Name = p.Name!,

                    Price = p.Variants
                        .OrderBy(v => v.Price)
                        .FirstOrDefault()?.Price ?? 0,

                    MainImage = p.Images
                        .FirstOrDefault(i => i.IsPrimary)?.ImageUrl,
                })
            };
            return new Response<HomeVM>(vm, null, false);
        } catch(Exception ex)
        {
            return new Response<HomeVM>(null!, ex.Message, true);
        }
    }
}
