
using EF_MSSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HustlersAB.Admin;

class Program
{
    static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var services = new ServiceCollection();

        services.AddDbContext<StoreDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        
        var serviceProvider = services.BuildServiceProvider();

    }
}