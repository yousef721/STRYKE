namespace STRYKE.BLL.Mapper;

public class DomainProfile : Profile
{
    public DomainProfile()
    {
        CreateMap<Category, CategoryHomeVM>().ReverseMap();
        CreateMap<Product, ProductHomeVM>().ReverseMap();
    }
}
