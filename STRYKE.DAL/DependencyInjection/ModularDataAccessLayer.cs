namespace STRYKE.DAL.DependencyInjection;

public static class ModularDataAccessLayer
{
    public static IServiceCollection  AddBusinessLayerInDAL(this IServiceCollection services)
    {
        // UNIT OF WORK
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // GENERIC REPOSITORY
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        // SPECIFIC REPOSITORIES
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
