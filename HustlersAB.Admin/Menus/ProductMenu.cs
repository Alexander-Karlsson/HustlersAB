using HustlersAB.Shared.Menus;
using Services.Interfaces.Categories;
using Services.Interfaces.Products;

namespace HustlersAB.Admin.Menus;

public class ProductMenu(AddProductMenu addProductMenu) : BaseMenu
{
    protected override string[] Options => 
        [
        "Add Product", 
        "Search Product(s)", 
        "Update Product", 
        "Delete Product", 
        "Go Back" 
        ];
    
    protected override string MenuTitle => "menu -> admin -> MANAGE PRODUCT";
    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                addProductMenu.Start();
                break;
            
            case 4: return true;
        }

        return false;
    } 
}