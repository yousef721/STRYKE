namespace STRYKE.BLL.Mapper;

public class DomainProfile : Profile
{
    public DomainProfile()
    {
        CreateMap<Category, CategoryHomeDto>().ReverseMap();
        CreateMap<Product, ProductHomeDto>().ReverseMap();
    }
}
