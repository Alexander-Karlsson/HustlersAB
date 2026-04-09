using HustlersAB.Shared.Menus;
using System;
using System.Collections.Generic;
using System.Text;

namespace HustlersAB.Client.Menus;

public class ClientMenu : BaseMenu
{
    protected override string[] Options =>
        [
        "Browse Products",
        "View Cart",
        "Exit"
        ];

    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                Console.WriteLine("Browsing products");
                return false;

            default:
                break;
        }
        return true;
    }
}
