
using HustlersAB.Admin.Menus;
using HustlersAB.Client;
using HustlersAB.Client.Menus;


// using HustlersAB.Client.Menus;
using HustlersAB.Shared.Menus;
using Microsoft.Extensions.DependencyInjection;

namespace HustlersAB.EntryPoint;

public class StartPageMenu(IServiceProvider serviceProvider, AdminMenu adminMenu) : BaseMenu
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

                new ClientMenu().Start();
                return false;
            case 2:
                // Exit
                Environment.Exit(0);
                break;
        }
        return false;
    }
}