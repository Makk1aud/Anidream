using Anidream.Api.Application.Utils.Interfaces.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Anidream.Api.DataAccess.Extensions;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddAnidreamDbContext(
        this IServiceCollection services,
        ConfigurationManager configurationManager)
    {
#if DEBUG
        return services.AddDbContext<IDbContext, AnidreamContext>(
            opt => opt.UseNpgsql(configurationManager.GetSection("DefaultConnection").Value));
#else
        return services.AddDbContext<IDbContext, AnidreamContext>(
            opt => opt.UseNpgsql(configurationManager.GetConnectionString("DefaultConnection")));
#endif
    }

    public static void EnsureDbCreated(this IServiceScope scope)
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AnidreamContext>();
        dbContext.Database.Migrate();
    }
}