using HustlersAB.Shared.Menus;
using Services.Interfaces.Products;

namespace HustlersAB.Admin.Menus;

public class DeleteProductMenu(
    IProductService productService) : BaseMenu
{
    protected override string[] Options =>
      [
        "Delete Product",
        "Go Back"
        ];

    protected override string MenuTitle => "menu -> admin -> DELETE PRODUCT";
    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                DeleteProduct();
                break;
            case 1:
                return true;
        }
        return false;
    }

    private void DeleteProduct()
    {
        Header("DELETE PRODUCT");

        var products = productService
            .GetAllAsync()
            .GetAwaiter()
            .GetResult()
            .ToList();

        if (!products.Any())
        {
            Pause("No products found.");
            return;
        }

        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i}. {products[i].Name} - {products[i].Price}");
        }

        Console.Write("Choose product number to delete:");
        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Invalid();
            return;
        }

        if (choice < 0 || choice > products.Count)
        {
            Invalid();
            return;
        }

        var selectedProduct = products[choice];

        Header("DELETE PRODUCT");
        Console.WriteLine($"Name: {selectedProduct.Name}");
        Console.WriteLine($"Price: {selectedProduct.Price}");
        Console.WriteLine($"Quantity in stock: {selectedProduct.QtyInStock}");
        Console.WriteLine();
        Console.WriteLine("Are you sure you want to delete this product? Y/N?");

        var confirm = Console.ReadLine();
        if (confirm?.ToLower() != "y")
        {
            Pause("No product was deleted.");
            return;
        }

        productService.DeleteAsync(selectedProduct.Id)
            .GetAwaiter()
            .GetResult();

        Pause("Product deleted successfully!");
    }
}
