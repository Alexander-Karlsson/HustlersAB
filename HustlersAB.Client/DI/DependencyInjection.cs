using HustlersAB.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace HustlersAB.Client.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddClientPresentation(
        this IServiceCollection services)
    {
        services.AddScoped<Cart>();
        services.AddScoped<StartPage>();
        

        return services;
    }
}