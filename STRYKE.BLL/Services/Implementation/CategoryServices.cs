


namespace STRYKE.BLL.Services.Implementation;

public class CategoryServices : ICategoryServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryServices(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ResponseResult<List<CategoryHomeDto>>> GetTopHomeCategoriesAsync(int count = 3)
    {
        var topCategories = await _unitOfWork.CategoryRepository.GetAllAsync(c => c.ShowInHomePage, c => c.Include(c => c.CategoryId), take: count, tracked: false);

        if (topCategories == null || !topCategories.Any())
            return ResponseResult<List<CategoryHomeDto>>.NotFound("No categories found");

        var categoriesDto = _mapper.Map<List<CategoryHomeDto>>(topCategories);

        return ResponseResult<List<CategoryHomeDto>>.Success(categoriesDto);
    }
}
