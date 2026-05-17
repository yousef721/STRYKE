namespace STRYKE.BLL.DependencyInjection;

public static class ModularBusinessLogicLayer
{
    public static IServiceCollection AddBusinessLayerInBLL(
        this IServiceCollection services)
    {
        // SERVICES
        services.AddScoped<IHomeServices, HomeServices>();

        services.AddScoped<IProductServices, ProductServices>();

        services.AddScoped<ICategoryServices, CategoryServices>();

        return services;
    }
}