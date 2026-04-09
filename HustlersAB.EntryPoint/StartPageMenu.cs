
using HustlersAB.Admin.Menus;
using HustlersAB.Client;

// using HustlersAB.Client.Menus;
using HustlersAB.Shared.Menus;
using Microsoft.Extensions.DependencyInjection;

namespace HustlersAB.EntryPoint;

public class StartPageMenu(IServiceProvider serviceProvider) : BaseMenu
{
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
                new AdminMenu().Start();
                break;
            case 1:
                // Starta ClientMenu
                // new ClientMenu().Start();
                var startPage = serviceProvider.GetRequiredService<StartPage>();
                startPage.Show().GetAwaiter().GetResult();
                break;
            case 2:
                // Exit
                Environment.Exit(0);
                break;
        }
        return false;
    }
}