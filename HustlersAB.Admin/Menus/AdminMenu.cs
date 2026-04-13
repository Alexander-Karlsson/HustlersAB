using HustlersAB.Shared.Menus;

namespace HustlersAB.Admin.Menus;

public class AdminMenu(ProductMenu productMenu) : BaseMenu
{
    protected override string[] Options =>
    [
        "Manage Products",
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