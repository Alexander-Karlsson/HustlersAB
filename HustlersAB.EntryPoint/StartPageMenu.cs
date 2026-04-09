
using HustlersAB.Admin.Menus;
// using HustlersAB.Client.Menus;
using HustlersAB.Shared.Menus;

namespace HustlersAB.EntryPoint;

public class StartPageMenu : BaseMenu
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
                break;
            case 2:
                // Exit
                Environment.Exit(0);
                break;
        }
        return false;
    }
}