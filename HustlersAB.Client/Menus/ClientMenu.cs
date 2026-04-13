using HustlersAB.Shared;
using HustlersAB.Shared.Menus;
using Services.Interfaces.Products;

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
                new ProductsMenu(service).Start();
                return false;
            case 1:
                new ShopingCartMenu(cart).Start();
                return false;
        }

        return true;
    }
}