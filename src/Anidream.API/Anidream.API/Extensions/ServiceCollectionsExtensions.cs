using DataAccess;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Anidream.API.Extensions;

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

    public static void EnsureDbCreated(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AnidreamContext>();
        dbContext.Database.Migrate();
    }
}