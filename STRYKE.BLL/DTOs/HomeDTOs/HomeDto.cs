namespace STRYKE.BLL.ViewModel.Home;

public class HomeDto
{
    public IEnumerable<CategoryHomeDto> Categories { get; set; } = [];
    public IEnumerable<ProductHomeDto> Products { get; set; } = [];
}
