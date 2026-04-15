using HustlersAB.Admin.Menus;
using HustlersAB.Client;
using HustlersAB.Client.Menus;
using Entities;
using HustlersAB.Shared;
using HustlersAB.Shared.Menus;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces.Customers;
using Services.Interfaces.Products;
using Services.Interfaces.Shipping;

namespace HustlersAB.EntryPoint;

public class StartPageMenu(ICustomerService customerService, IProductService service, IServiceProvider serviceProvider, AdminMenu adminMenu, Cart cart, IShippingService shippingService) : BaseMenu
{
    private readonly AdminMenu _adminMenu = adminMenu;
    protected override string[] Options =>
    [
        "Admin Mode",
        "Client Mode",
        "Exit Application"
    ];

    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                // Starta AdminMenu
                if (AskForPassword())
                {
                    _adminMenu.Start();
                }
                else
                {
                    Console.WriteLine("Wrong password... Press any key.");
                    Console.ReadKey();
                }
                return false;
            case 1:
                // Starta ClientMenu
                var startPage = serviceProvider.GetRequiredService<StartPage>();
                startPage.Show().GetAwaiter().GetResult();

                new ClientMenu(service, cart, shippingService).Start();
                return false;
            case 2:
                // Exit
                Environment.Exit(0);
                break;
            }
        return false;
    }
    private bool AskForPassword()
    {
        Console.Clear();
        Console.WriteLine("Enter admin password: ");
        var input = Console.ReadLine();

        return input == "2026";
    }
}