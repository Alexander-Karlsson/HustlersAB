using HustlersAB.Shared.Menus;
using Services.Interfaces.Products;

namespace HustlersAB.Admin.Menus;

public class SearchProductMenu(IProductService productService) : BaseMenu
{
    protected override string[] Options =>
    [
        "Search Product",
        "Go back"
    ];

    protected override string MenuTitle => "menu -> admin -> SEARCH PRODUCT";

    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                SearchProduct();
                break;
            case 1:
                return true;
        }

        return false;
    }

    private void SearchProduct()
    {
        Console.Clear();
        Console.WriteLine("SEARCH PRODUCT");
        Console.WriteLine("---------------");

        Console.Write("Search: ");
        
        Console.CursorVisible = true;
        var query = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(query))
        {
            Invalid();
            return;
        }

        Console.CursorVisible = false;

        var result = productService
            .GetBySearchAsync(query)
            .GetAwaiter()
            .GetResult()
            .ToList();

        Console.Clear();
        Console.WriteLine($"Result for: {query}");
        Console.WriteLine("--------------------");

        if (!result.Any())
        {
            Console.WriteLine("No products found... Press any key to continue.");
            Console.ReadKey();
            return;
        }

        for (var i = 0; i < result.Count; i++)
        {
            var p = result[i];
            Console.WriteLine($"{i}. {p.Name} - {p.Price} kr - Stock: {p.QtyInStock}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}