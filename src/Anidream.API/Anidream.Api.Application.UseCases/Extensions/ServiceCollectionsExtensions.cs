using Anidream.Api.Application.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Anidream.Api.Application.UseCases.Extensions;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddApplicationUseCases(this IServiceCollection services) =>
        services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyInfo).Assembly))
            .AddAutoMapper(cfg => cfg.AddProfile(typeof(ProfilesBase)));
}