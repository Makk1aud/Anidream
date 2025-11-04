namespace Anidream.Api.Extensions;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        return services
            .AddDataAccess(GetConnectionString(configurationManager))
            .AddInfrastructure()
            .AddApplication();
    }
    
    public static void EnsureDbCreated(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        scope.EnsureDbCreated();
    }

    private static string GetConnectionString(ConfigurationManager configurationManager)
    {
#if DEBUG
        return configurationManager.GetSection("DefaultConnection").Value ?? throw new InvalidOperationException("No connection string configured");
#else
        return configurationManager.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("No connection string configured");
#endif
    }
}