using Anidream.Api.Application.Core;
using Anidream.Api.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Anidream.Api.Application.Extensions;

public static class ServiceCollectionExtenseions
{
    public static IServiceCollection AddApplication(this IServiceCollection services) =>
        services
            .AddScoped<IMediaService, MediaService>();
}