namespace STRYKE.BLL.ViewModel.Home;

public class HomeVM
{
    public IEnumerable<CategoryHomeVM> Categories { get; set; } = [];
    public IEnumerable<ProductHomeVM> Products { get; set; } = [];
}
