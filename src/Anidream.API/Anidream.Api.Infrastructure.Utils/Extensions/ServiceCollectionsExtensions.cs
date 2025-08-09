using Microsoft.Extensions.DependencyInjection;
using Anidream.Api.DataAccess.Extensions;
using Microsoft.Extensions.Configuration;

namespace Anidream.Api.Infrastructure.Utils.Extensions;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        return services.AddAnidreamDbContext(connectionString);
    }
}