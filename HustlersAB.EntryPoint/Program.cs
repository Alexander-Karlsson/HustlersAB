
using EF_MSSQL.DI;
using HustlersAB.Admin.DI;
using HustlersAB.Client.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.DI;
using HustlersAB.Client;
using HustlersAB.Admin;

namespace HustlersAB.EntryPoint;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var services = new ServiceCollection();

        services.AddInfrastructure(config)
            .AddApplicationServices()
            .AddAdminPresentation()
            .AddClientPresentation();

        services.AddScoped<StartPageMenu>();

        var serviceProvider = services.BuildServiceProvider();

        var startMenu = serviceProvider.GetRequiredService<StartPageMenu>();
        Console.CursorVisible = false;
        startMenu.Start();
    }
}