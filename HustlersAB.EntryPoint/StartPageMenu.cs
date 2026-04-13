
using HustlersAB.Admin.Menus;
using HustlersAB.Client;
using HustlersAB.Client.Menus;
using HustlersAB.Shared;



// using HustlersAB.Client.Menus;
using HustlersAB.Shared.Menus;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces.Products;

namespace HustlersAB.EntryPoint;

public class StartPageMenu(IProductService service, IServiceProvider serviceProvider, AdminMenu adminMenu, Cart cart) : BaseMenu
{
    private readonly AdminMenu _adminMenu = adminMenu;
    protected override string[] Options =>
    [
        "Admin Mode",
        "Client Mode",
        "\nExit Application"
        
    ];

    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                // Starta AdminMenu
                _adminMenu.Start();
                break;
            case 1:
                // Starta ClientMenu
                var startPage = serviceProvider.GetRequiredService<StartPage>();
                startPage.Show().GetAwaiter().GetResult();

                new ClientMenu(service, cart).Start();
                return false;
            case 2:
                // Exit
                Environment.Exit(0);
                break;
        }
        return false;
    }
}