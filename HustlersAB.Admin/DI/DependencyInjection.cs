using HustlersAB.Admin.Menus;
using Microsoft.Extensions.DependencyInjection;

namespace HustlersAB.Admin.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddAdminPresentation(this IServiceCollection services)
    {
        services.AddScoped<AdminMenu>();
        services.AddScoped<AddProductMenu>();
        services.AddScoped<DeleteProductMenu>();
        services.AddScoped<SearchProductMenu>();
        services.AddScoped<ProductMenu>();

        return services;
    }
}