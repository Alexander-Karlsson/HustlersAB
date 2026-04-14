using HustlersAB.Shared.Menus;
using System;
using Entities;
using System.Collections.Generic;
using System.Text;
using HustlersAB.Admin.Menus;
using Services.Interfaces.Products;
using HustlersAB.Shared;

namespace HustlersAB.Client.Menus;

public class ClientMenu(IProductService service, Cart cart) : BaseMenu
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
                new ProductsMenu(service, cart).Start();
                return false;
            case 1:
                new ShopingCartMenu(cart).Start();
                return false;
            default:
                break;
        }
        return true;
    }
}
