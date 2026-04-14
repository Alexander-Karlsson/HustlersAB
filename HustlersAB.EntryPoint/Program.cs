using System.Net.Security;
using EF_MSSQL;
using EF_MSSQL.Repositories;
using HustlersAB.Admin;
using HustlersAB.Admin.Menus;
using HustlersAB.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interfaces.Categories;
using Services.Interfaces.Customers;
using Services.Interfaces.Manufacturers;
using Services.Interfaces.Orders;
using Services.Interfaces.Products;
using Services.Interfaces.Quotes;
using HustlersAB.Shared;
using Entities;
using HustlersAB.Admin.Menus.CustomerMenus;
using HustlersAB.Admin.Menus.ProductMenus;

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
        
        services.AddScoped<IProductSubCategoryRepository, ProductSubCategoryRepository>();
        services.AddScoped<IProductSubCategoryService, ProductSubCategoryService>();

        services.AddScoped<IQuoteRepository, QuoteRepository>();
        services.AddScoped<IQuoteService, QuoteService>();

        services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
        services.AddScoped<IManufacturerService, ManufacturerService>();
        
        services.AddScoped<Cart>();
        services.AddScoped<StartPage>();
        services.AddScoped<StartPageMenu>();
        services.AddScoped<AddProductMenu>();
        services.AddScoped<ProductMenu>();
        services.AddScoped<AdminMenu>();
        services.AddScoped<DeleteProductMenu>();
        services.AddScoped<SearchProductMenu>();
        services.AddScoped<UpdateProductMenu>();
        services.AddScoped<StockMenu>();
        services.AddScoped<CustomerMenu>();
        

        var serviceProvider = services.BuildServiceProvider();

        var startMenu = serviceProvider.GetRequiredService<StartPageMenu>();
        startMenu.Start();
        
    }
}