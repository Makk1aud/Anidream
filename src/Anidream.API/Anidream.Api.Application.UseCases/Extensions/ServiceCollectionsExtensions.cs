using Anidream.Api.Application.Utils;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Anidream.Api.Application.UseCases.Extensions;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddApplicationUseCases(this IServiceCollection services)
    {
       //return services.AddMediatR(typeof(AssemblyInfo).Assembly);
       return services;
    }
}