using Entities;
using HustlersAB.Shared.Menus;
using Services.Interfaces.Products;

namespace HustlersAB.Client.Menus;

public class ClientMenu(ShopingCartMenu cartMenu, IProductService service, Cart cart) : BaseMenu
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
                cartMenu.Start();
                return false;
            default:
                break;
        }
        return true;
    }
}
