using HustlersAB.Admin.Menus.CustomerMenus;
using HustlersAB.Admin.Menus.ProductMenus;
using HustlersAB.Shared.Menus;

namespace HustlersAB.Admin.Menus;

public class AdminMenu(ProductMenu productMenu,
    StartPageProductsMenu startPageProductsMenu,
    CustomerMenu customerMenu) : BaseMenu
{
    protected override string[] Options => 
        [ 
        "Manage Products",
        "Manage Start Page Products",
        "Manage Customers", 
        "Manage Orders", 
        "Go Back" 
        ];
    
    protected override string MenuTitle => "menu -> ADMIN";
    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                productMenu.Start();
                break;
            case 1:
                startPageProductsMenu.Start();
                break;
            case 2: 
                customerMenu.Start();
                break;
            case 3: 
                new OrderMenu().Start(); 
                break;
            case 4: return true;
        }

        return false;
    } 
}