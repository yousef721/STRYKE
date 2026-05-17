namespace STRYKE.BLL.Common.DependencyInjection;

public static class ModularBusinessLogicLayer
{
    public static IServiceCollection AddBusinessLayerInBLL(
        this IServiceCollection services)
    {
        // SERVICES
        services.AddScoped<IProductServices, ProductServices>();

        services.AddScoped<ICategoryServices, CategoryServices>();

        // MAPPER
        services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

        return services;
    }
}