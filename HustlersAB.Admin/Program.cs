


using EF_MSSQL;
using EF_MSSQL.Repositories;
using HustlersAB.Admin.Menus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interfaces;

namespace HustlersAB.Admin;

class Program
{
    static void Main(string[] args)
    {

        var mainMenu = new MainMenu();
        mainMenu.ShowMenu("Test Meny");

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var services = new ServiceCollection();

        services.AddDbContext<StoreDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

        var serviceProvider = services.BuildServiceProvider();

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomerService, CustomerService>();

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderService, OrderService>();

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderService, OrderService>();


        var customerService = serviceProvider.GetRequiredService<ICustomerService>();



    }//Hej hej
    //Hi again
}