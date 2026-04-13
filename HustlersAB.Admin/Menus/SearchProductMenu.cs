using HustlersAB.Shared.Menus;
using Services.Interfaces.Products;

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
      Console.Clear();
      Console.WriteLine("SEARCH");
      Console.WriteLine("-----------");
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
        Console.WriteLine($"Result: {result.Count}");
        Console.WriteLine("-----------");

    if (!result.Any())
    {
        Console.WriteLine("No products found.");
        Console.ReadKey();
        return;
    }

    foreach (var p in result)
    {
        Console.WriteLine($"{p.Name} - {p.Price} SEK");
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}