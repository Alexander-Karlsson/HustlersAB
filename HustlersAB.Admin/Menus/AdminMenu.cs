
using HustlersAB.Admin.Menus.CustomerMenus;
using HustlersAB.Admin.Menus.ProductMenus;
using HustlersAB.Shared.Menus;
using Services.Interfaces.Categories;
using Services.Interfaces.Customers;
using Services.Interfaces.Products;

namespace HustlersAB.Admin.Menus;

<<<<<<< HEAD
public class AdminMenu(ProductMenu productMenu,
    StartPageProductsMenu startPageProductsMenu) : BaseMenu
=======
public class AdminMenu(CustomerMenu customerMenu, ProductMenu productMenu) : BaseMenu
>>>>>>> c3345bb6481d4b32bef63bd99eeb12d47a7e261e
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
<<<<<<< HEAD
            case 1:
                startPageProductsMenu.Start();
=======
            case 1: 
                customerMenu.Start(); 
>>>>>>> c3345bb6481d4b32bef63bd99eeb12d47a7e261e
                break;
            case 2:
                new CustomerMenu().Start();
                break;
            case 3: 
                new OrderMenu().Start(); 
                break;
            case 4: return true;
        }

        return false;
    } 
}