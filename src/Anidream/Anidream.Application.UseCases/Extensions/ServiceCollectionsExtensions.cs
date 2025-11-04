using Anidream.Application.UseCases;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services) =>
        services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyInfo).Assembly))
            .AddAutoMapper(cfg => cfg.AddProfile(typeof(ProfilesBase)));
}