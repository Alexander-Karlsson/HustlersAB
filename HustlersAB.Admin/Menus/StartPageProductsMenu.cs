using Entities;
using HustlersAB.Shared.Menus;
using Services.Interfaces.Products;

namespace HustlersAB.Admin.Menus;

public class StartPageProductsMenu(IProductService productService, MenuHelper menuHelper) : BaseMenu
{
    protected override string[] Options =>
    [
        "Change Start Page Products",
        "Go Back"
    ];

    protected override string MenuTitle => "menu -> admin -> START PAGE PRODUCTS";

    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                SetStartPageProducts();
                break;
            case 1:
                return true;
        }
        return false;
    }

    private void SetStartPageProducts()
    {
        Header("SET START PAGE PRODUCTS");

        var products = menuHelper.GetProducts();
        if (!products.Any())
        {
            Pause("No products found.");
            return;
        }

        ShowProducts(products);
        Console.WriteLine();

        var selectedIndexes = ReadThreeIndexes(products);
        if (selectedIndexes == null) return;

        var selectedIds = selectedIndexes
            .Select(i => products[i].Id)
            .ToList();

        productService.SetStartPageProductsAsync(selectedIds)
            .GetAwaiter()
            .GetResult();

        ShowUpdated(products, selectedIndexes);
    }

    private List<int>? ReadThreeIndexes(List<Product> products)
    {
        var first = ReadProductIndex("Choose first product: ", products);
        var second = ReadProductIndex("Choose second product: ", products);
        var third = ReadProductIndex("Choose third product: ", products);

        if (first == null || second == null || third == null)
        {
            Invalid();
            return null;
        }

        if (first == second || first == third || second == third)
        {
            Pause("You need to choose three different products!");
            return null;
        }

        return [first.Value, second.Value, third.Value];
    }

    private void ShowUpdated(List<Product> products, List<int> indexes)
    {
        Header("START PAGE UPDATED");

        for (int i = 0; i < indexes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {products[indexes[i]].Name}");
        }

        Pause();
    }

    private void ShowProducts(List<Product> products)
    {
        for (int i = 0; i < products.Count; i++)
        {
            var product = products[i];
            string startPage = product.IsStartPage ? " [START PAGE]" : "";

            Console.WriteLine($"{i}. {product.Name} - {product.Price} kr{startPage}");
        }
    }

    private int? ReadProductIndex(string message, List<Product> products)
    {
        Console.Write(message);

        if (!int.TryParse(Console.ReadLine(), out int choice) ||
            choice < 0 || choice >= products.Count)
        {
            return null;
        }
        return choice;
    }
}