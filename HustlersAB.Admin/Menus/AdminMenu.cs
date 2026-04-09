
using HustlersAB.Shared.Menus;

namespace HustlersAB.Admin.Menus;

public class AdminMenu : BaseMenu
{
    protected override string[] Options => new[] { "Manage Products", "Manage Customers", "Manage Orders", "\nGo Back" };
    
    protected override string MenuTitle => "menu -> ADMIN";
    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0: 
                new ProductMenu().Start(); 
                break;
            case 1: 
                new CustomerMenu().Start(); 
                break;
            case 2: 
                new OrderMenu().Start(); 
                break;
            case 3: return true;
        }

        return false;
    } 
}