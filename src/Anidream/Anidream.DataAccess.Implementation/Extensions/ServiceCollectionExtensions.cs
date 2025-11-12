using Anidream.Application.Interfaces;
using Anidream.DataAccess;
using Anidream.DataAccess.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
        services.AddScoped<IMediaRepository, MediaRepository>();
        
        services.AddDbContext<AnidreamContext>(opt => opt
            .UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention());
        return services;
    }
    
    public static void EnsureDbCreated(this IServiceScope scope)
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AnidreamContext>();
        dbContext.Database.Migrate();
    }
}