using HustlersAB.Shared.Menus;
using Services.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace HustlersAB.Admin.Menus;

public class SearchProductMenu(
    IProductService productService) : BaseMenu
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
        Header("SEARCH");

        Console.Write("Search:");
        var query = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(query))
        {
            Invalid();
            return;
        }

        var result = productService
            .GetBySearchAsync(query)
            .GetAwaiter()
            .GetResult()
            .ToList();

        Header($"Result: {result.Count}");

        if (!result.Any())
        {
            Pause("No products found.");
            return;
        }

        foreach (var p in result)
        {
            Console.WriteLine($"{p.Name} - {p.Price} SEK");
        }
        Pause();
    }
}
