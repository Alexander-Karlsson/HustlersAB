using EF_MSSQL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces.Categories;
using Services.Interfaces.Customers;
using Services.Interfaces.Manufacturers;
using Services.Interfaces.Orders;
using Services.Interfaces.Products;
using Services.Interfaces.Quotes;

namespace EF_MSSQL.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<StoreDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductSubCategoryRepository, ProductSubCategoryRepository>();
        services.AddScoped<IQuoteRepository, QuoteRepository>();
        services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
        
        return services;
    }
}