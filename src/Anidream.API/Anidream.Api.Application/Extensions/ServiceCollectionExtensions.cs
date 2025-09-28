using Anidream.Api.Application.Core;
using Anidream.Api.Application.DatabaseServices;
using Anidream.Api.Application.Options;
using Anidream.Api.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Anidream.Api.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IMediaStorageService, MediaStorageService>();
        services.AddScoped<IFileStorageClient, PhysicalFileStorageClient>();
        services.AddScoped<IMediaService, MediaService>();
        services.AddOptionsWithValidateOnStart<StorageOptions>()
            .BindConfiguration(StorageOptions.SectionName)
            .ValidateDataAnnotations();
        
        services.AddSingleton<IStorageConnectionProvider, StorageConnectionProvider>();
        return services;
    }
}