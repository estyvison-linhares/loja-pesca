using LojaPesca.Application.Interfaces;
using LojaPesca.Application.Services;
using LojaPesca.Domain.Interfaces;
using LojaPesca.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LojaPesca.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Register repositories
        services.AddSingleton<IProductRepository, InMemoryProductRepository>();

        // Register services
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
