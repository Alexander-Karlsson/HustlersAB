using HustlersAB.Shared.Menus;
using System;
using System.Collections.Generic;
using System.Text;
using HustlersAB.Admin.Menus;
using Services.Interfaces.Products;

namespace HustlersAB.Client.Menus;

public class ClientMenu(IProductService service) : BaseMenu
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
                new ProductsMenu(service).Start();
                return false;
            

            default:
                break;
        }
        return true;
    }
}
