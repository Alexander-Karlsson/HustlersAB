using HustlersAB.Shared.Menus;
using Services.Interfaces.Categories;
using Services.Interfaces.Products;

namespace HustlersAB.Admin.Menus;

public class ProductMenu(AddProductMenu addProductMenu,
    DeleteProductMenu deleteProductMenu,
    SearchProductMenu searchProductMenu) : BaseMenu
{
    protected override string[] Options => 
        [
        "Add Product",
        "Delete Product",
        "Search Product(s)", 
        "Update Product",  
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
            case 1:
                deleteProductMenu.Start();
                break;
            case 2:
                searchProductMenu.Start();
                break;
            
            case 4: return true;
        }

        return false;
    } 
}