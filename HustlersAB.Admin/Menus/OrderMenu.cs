using HustlersAB.Shared.Menus;

namespace HustlersAB.Admin.Menus;

public class OrderMenu : BaseMenu
{
    protected override string[] Options => new[]
        { "Add Order", "Search Order(s)", "Update Order", "Delete Order", "\nGo Back" };

    protected override string MenuTitle => "menu -> admin -> MANAGE ORDERS";

    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 4: return true;
        }

        return false;
    }
}