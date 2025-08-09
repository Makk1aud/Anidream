using Anidream.Api.Application.Utils.Extensions;
using Anidream.Api.DataAccess.Extensions;
using Anidream.Api.Infrastructure.Utils.Extensions;

namespace Anidream.API.Extensions;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        return services
            .AddInfrastructure(configurationManager)
            .AddApplication();
    }
    
    public static void EnsureDbCreated(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        scope.EnsureDbCreated();
    }
}