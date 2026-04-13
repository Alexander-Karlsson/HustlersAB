using HustlersAB.Shared.Menus;

namespace HustlersAB.Admin.Menus;

public class CustomerMenu : BaseMenu
{
    protected override string[] Options => new[]
        { "Add Customer", "Search Customer(s)", "Update Customer", "Delete Customer", "\nGo Back" };

    protected override string MenuTitle => "menu -> admin -> MANAGE CUSTOMERS";

    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 4: return true;
        }

        return false;
    }
}