using Anidream.Application.Interfaces;
using Anidream.Application.Services;
using Anidream.Application.UseCases;
using Anidream.Application.UseCases.Behaviors;
using FluentValidation;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services) =>
        services
            .AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(AssemblyInfo).Assembly);
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            })
            .AddValidatorsFromAssembly(typeof(AssemblyInfo).Assembly)
            .AddAutoMapper(cfg => cfg.AddProfile(typeof(ProfilesBase)));
}