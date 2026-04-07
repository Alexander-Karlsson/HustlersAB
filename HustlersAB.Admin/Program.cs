


using EF_MSSQL;
using EF_MSSQL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interfaces;

namespace HustlersAB.Admin;

class Program
{
    static async Task Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var services = new ServiceCollection();

        services.AddDbContext<StoreDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));


        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomerService, CustomerService>();
        
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderService, OrderService>();
        
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();

        services.AddScoped<StartPage>();

        var serviceProvider = services.BuildServiceProvider();

        var customerService = serviceProvider.GetRequiredService<ICustomerService>();

        var startPage = serviceProvider.GetRequiredService<StartPage>();
        await startPage.Show();
    }
}