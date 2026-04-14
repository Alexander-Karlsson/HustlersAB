
using HustlersAB.Shared.Menus;
using Services.Interfaces.Categories;
using Services.Interfaces.Products;

namespace HustlersAB.Admin.Menus;

public class AdminMenu(ProductMenu productMenu,
    StartPageProductsMenu startPageProductsMenu) : BaseMenu
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