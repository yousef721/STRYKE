namespace STRYKE.ViewModels.HomeVM;

public class ProductVM
{
    public string? Slug { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string? MainImage { get; set; }
}
