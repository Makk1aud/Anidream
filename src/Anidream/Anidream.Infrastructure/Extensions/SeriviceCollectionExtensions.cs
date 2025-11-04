using Anidream.Application.Interfaces;
using Anidream.Infrastructure;
using Anidream.Infrastructure.FileSystemStorage;
using Anidream.Infrastructure.FileSystemStorage.Interfaces;

namespace Microsoft.Extensions.DependencyInjection;

public static class SeriviceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IMediaStorageService, FileSystemMediaStorageService>();
        services.AddScoped<IFileStorageClient, FileSystemFileStorageClient>();
        services.AddScoped<IStorageConnectionProvider, FileSystemStorageConnectionProvider>();
        services.AddOptionsWithValidateOnStart<FileSystemStorageOptions>()
            .BindConfiguration(FileSystemStorageOptions.SectionName)
            .ValidateDataAnnotations();
        return services;
    }
}