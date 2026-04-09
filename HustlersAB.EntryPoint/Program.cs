using EF_MSSQL;
using EF_MSSQL.Repositories;
using HustlersAB.Admin;
using HustlersAB.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interfaces;

namespace HustlersAB.EntryPoint;

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

        services.AddScoped<IQuoteRepository, QuoteRepository>();
        services.AddScoped<IQuoteService, QuoteService>();

        services.AddScoped<StartPage>();
        services.AddScoped<StartPageMenu>();

        var serviceProvider = services.BuildServiceProvider();

        var startMenu = serviceProvider.GetRequiredService<StartPageMenu>();
        startMenu.Start();
        
    }
}