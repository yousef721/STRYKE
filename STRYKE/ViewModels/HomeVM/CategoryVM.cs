namespace STRYKE.ViewModels.HomeVM;

public class CategoryVM
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public string? Image { get; set; }
}
