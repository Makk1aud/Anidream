using Anidream.Api.Application.UseCases.Extensions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Anidream.Api.Application.Utils.Extensions;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //return services.AddApplicationUseCases();
        return services;
    }
}