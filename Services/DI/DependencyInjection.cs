using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces.Categories;
using Services.Interfaces.Customers;
using Services.Interfaces.Manufacturers;
using Services.Interfaces.Orders;
using Services.Interfaces.Products;
using Services.Interfaces.Quotes;

namespace Services.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductSubCategoryService, ProductSubCategoryService>();
        services.AddScoped<IQuoteService, QuoteService>();
        services.AddScoped<IManufacturerService, ManufacturerService>();

        return services;
    }
}