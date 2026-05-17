namespace STRYKE.BLL.DTOs.HomeDTOs;

public class HomeDto
{
    public IEnumerable<CategoryHomeDto> Categories { get; set; } = [];
    public IEnumerable<ProductHomeDto> Products { get; set; } = [];
}
