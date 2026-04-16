using HustlersAB.Admin.Menus.CustomerMenus;
using HustlersAB.Admin.Menus.OrderMenus;
using HustlersAB.Admin.Menus.ProductMenus;
using HustlersAB.Shared.Menus;

namespace HustlersAB.Admin.Menus;

public class AdminMenu(ProductMenu productMenu,
    StartPageProductsMenu startPageProductsMenu,
    CustomerMenu customerMenu,
    OrderMenu orderMenu,
    AddManufacturerMenu addManufacturerMenu) : BaseMenu
{
    protected override string[] Options => 
        [ 
        "Manage Products",
        "Manage Start Page Products",
        "Manage Customers", 
        "Manage Orders", 
        "Manage Manufacturer",
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
                orderMenu.Start(); 
                break;
            case 4:
                addManufacturerMenu.Start();
                break;
            case 5:   
                return true;
        }

        return false;
    } 
}