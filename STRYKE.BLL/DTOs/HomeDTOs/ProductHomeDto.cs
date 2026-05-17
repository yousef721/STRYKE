namespace STRYKE.BLL.ViewModel.Home;

public class ProductHomeDto
{
    public string? Slug { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string? MainImage { get; set; }
}
