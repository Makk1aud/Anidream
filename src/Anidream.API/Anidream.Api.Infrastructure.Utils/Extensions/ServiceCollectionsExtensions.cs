using Anidream.Api.DataAccess.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Anidream.Api.Infrastructure.Utils.Extensions;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configurationManager)
    {
        return services.AddAnidreamDbContext(configurationManager);
    }
}