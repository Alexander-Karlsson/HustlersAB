using HustlersAB.Shared.Menus;

namespace HustlersAB.Admin.Menus;

public class ProductMenu : BaseMenu
{
    protected override string[] Options => new[] {"Add Product", "Search Product(s)", "Update Product", "Delete Product", "\nGo Back" };
    
    protected override string MenuTitle => "menu -> admin -> MANAGE PRODUCT";
    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            
            
            case 4: return true;
        }

        return false;
    } 
}