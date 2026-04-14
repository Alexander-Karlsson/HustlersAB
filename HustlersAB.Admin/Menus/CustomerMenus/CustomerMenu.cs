using HustlersAB.Shared.Menus;
using Services.Interfaces.Customers;

namespace HustlersAB.Admin.Menus.CustomerMenus;

public class CustomerMenu(AddCustomerMenu addCustomer) : BaseMenu
{
    protected override string[] Options =>
    [
        "Add Customer",
        "Delete Customer",
        "Search Customer(s)",
        "Update Customer",
        "Go Back" 
    ];
    
    protected override string MenuTitle => "menu -> admin -> MANAGE CUSTOMERS";
    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                addCustomer.Start();
                break;
            case 1:
                // Delete
            case 2:
                // Search
            case 3:
                // Update
            case 4: return true;
        }

        return false;
    } 
}