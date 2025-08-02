using Infrastructure.Utils.Extensions;

namespace Anidream.API.Extensions;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        return services.AddInfrastructure(configurationManager);
    }
    
    public static void EnsureDbCreated(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        scope.EnsureDbCreated();
    }
}