using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Anidream.Api.Application.Utils.Interfaces.Data;
using Microsoft.Extensions.Configuration;

namespace Anidream.Api.DataAccess.Extensions;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddAnidreamDbContext(this IServiceCollection services, string connectionString)
    {
        return services.AddDbContext<IDbContext, AnidreamContext>(opt => opt
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention());
    }

    public static void EnsureDbCreated(this IServiceScope scope)
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AnidreamContext>();
        dbContext.Database.Migrate();
    }
}