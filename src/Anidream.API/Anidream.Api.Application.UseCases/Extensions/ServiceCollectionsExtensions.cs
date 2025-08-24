using Anidream.Api.Application.UseCases.Services;
using Anidream.Api.Application.UseCases.Services.Interfaces;
using Anidream.Api.Application.Utils;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Anidream.Api.Application.UseCases.Extensions;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddApplicationUseCases(this IServiceCollection services) =>
        services
            .AddScoped<IMediaService, MediaService>()
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyInfo).Assembly))
            .AddAutoMapper(cfg => cfg.AddProfile(typeof(ProfilesBase)));
}