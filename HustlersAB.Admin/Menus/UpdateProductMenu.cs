using Entities;
using HustlersAB.Shared.Menus;
using Services.Interfaces.Categories;
using Services.Interfaces.Manufacturers;
using Services.Interfaces.Products;

namespace HustlersAB.Admin.Menus;

public class UpdateProductMenu(IProductService productService,
    IProductSubCategoryService productSubCategoryService,
    IManufacturerService manufacturerService) : BaseMenu
{
    protected override string[] Options => 
        [
        "Update Product", 
        "Go Back"
        ];

    protected override string MenuTitle => "menu -> admin -> UPDATE PRODUCT";

    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                UpdateProduct();
                break;
            case 1:
                return true;
        }
        return false;
    }
    private void UpdateProduct()
    {
        Header("UPDATE PRODUCT");

        var products = GetProducts();
        if (products == null)
            return;

        var selectedProduct = SelectProduct(products);
        if (selectedProduct == null)
            return;

        EditProduct(selectedProduct);
        UpdateSubCategory(selectedProduct);
        UpdateManufacturer(selectedProduct);
        SaveProduct(selectedProduct);
    }

    private List<Product>? GetProducts()
    {
        var products = productService
            .GetAllAsync()
            .GetAwaiter()
            .GetResult()
            .ToList();

        if (!products.Any())
        {
            Pause("No products found.");
            return null;
        }
        return products;
    }

    private Product? SelectProduct(List<Product> products)
    {
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i}. {products[i].Name} - {products[i].Price} kr");
        }

        Console.Write("Choose product number to update: ");
        if (!int.TryParse(Console.ReadLine(), out int choice) ||
            choice < 0 || choice >= products.Count)
        {
            Invalid();
            return null;
        }
        return products[choice];
    }

    private void EditProduct(Product selectedProduct)
    {
        Header("EDIT PRODUCT");
        Console.WriteLine("Leave empty to keep current value.");
        Console.WriteLine();

        selectedProduct.Name = ReadUpdatedString("Name", selectedProduct.Name);
        selectedProduct.Description = ReadUpdatedString("Description", selectedProduct.Description);

        var updatedPrice = ReadUpdatedDecimal("Price", selectedProduct.Price);
        if (updatedPrice != null)
            selectedProduct.Price = updatedPrice.Value;

        var updatedQty = ReadUpdatedInt("Quantity in stock", selectedProduct.QtyInStock);
        if (updatedQty != null)
            selectedProduct.QtyInStock = updatedQty.Value;
    }

    private void UpdateSubCategory(Product selectedProduct)
    {
        if (!Change("Change subcategory? Y/N: "))
            return;

        var subCategories = productSubCategoryService
            .GetAllAsync()
            .GetAwaiter()
            .GetResult()
            .ToList();

        var subCategoryMenu = new SelectSubCategoryMenu(subCategories);
        subCategoryMenu.Start();

        Console.Clear();

        if (subCategoryMenu.SelectedSubCategory == null)
        {
            Invalid();
            return;
        }
        selectedProduct.SubCategoryId = subCategoryMenu.SelectedSubCategory.Id;
    }

    private void UpdateManufacturer(Product selectedProduct)
    {
        if (!Change("Change manufacturer? Y/N: "))
            return;

        var manufacturers = manufacturerService
            .GetAllAsync()
            .GetAwaiter()
            .GetResult()
            .ToList();

        var manufacturerMenu = new SelectManufacturerMenu(manufacturers);
        manufacturerMenu.Start();

        Console.Clear();
        if (manufacturerMenu.SelectedManufacturer == null)
        {
            Invalid();
            return;
        }
        selectedProduct.ManufacturerId = manufacturerMenu.SelectedManufacturer.Id;
    }
    private void SaveProduct(Product selectedProduct)
    {
        productService.UpdateAsync(selectedProduct)
            .GetAwaiter()
            .GetResult();

        Console.WriteLine("Product updated successfully!");
        Console.WriteLine("----------------------------");
        Console.WriteLine($"Name: {selectedProduct.Name}");
        Console.WriteLine($"Description: {selectedProduct.Description}");
        Console.WriteLine($"Price: {selectedProduct.Price}");
        Console.WriteLine($"Stock: {selectedProduct.QtyInStock}");
        Pause();
    }

    private bool Change(string message)
    {
        Console.Write(message);
        return Console.ReadLine()?.Trim().ToLower() == "y";
    }

    private string ReadUpdatedString(string text, string currentValue)
    {
        Console.Write($"{text} ({currentValue}): ");
        var input = Console.ReadLine();

        return string.IsNullOrWhiteSpace(input) ? currentValue : input;
    }

    private decimal? ReadUpdatedDecimal(string text, decimal currentValue)
    {
        Console.Write($"{text} ({currentValue}): ");
        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
            return currentValue;

        return decimal.TryParse(input, out var value) ? value : null;
    }

    private int? ReadUpdatedInt(string text, int currentValue)
    {
        Console.Write($"{text} ({currentValue}): ");
        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
            return currentValue;

        return int.TryParse(input, out var value) ? value : null;
    }
}
