using Entities;
using HustlersAB.Shared.Menus;
using Services.Interfaces.Categories;
using Services.Interfaces.Manufacturers;
using Services.Interfaces.Products;

namespace HustlersAB.Admin.Menus;

public class AddProductMenu(IProductSubCategoryService subCategoryService, 
    IManufacturerService manufacturerService) : BaseMenu
{
    protected override string[] Options => 
        [ 
        "Create Product", 
        "Go Back"
        ];

    protected override string MenuTitle => "menu -> admin -> ADD PRODUCT";

    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                AddProduct();
                break;
            case 1:
                return true;
        }
        return false;
    } 

    private void AddProduct()
    {
        Console.Clear();
        Console.WriteLine("ADD PRODUCT");
        Console.WriteLine("-----------");

        var name = ReadString("Name");
        var description = ReadString("Description");

        var price = ReadDecimal("Price");
        var qtyInStock = ReadInt("Quantity in stock");

        if (name == null || description == null || 
            price == null || qtyInStock == null)
        {
            Invalid();
            return;
        }

        var subCategories = subCategoryService
            .GetAllAsync()
            .GetAwaiter()
            .GetResult()
            .ToList();

        var subCategoryMenu = new SelectSubCategoryMenu(subCategories);
        subCategoryMenu.Start();

        var selectedSubCategory = subCategoryMenu.SelectedSubCategory;
        if (selectedSubCategory == null)
        {
            Invalid();
            return;
        }

        var manufacturers = manufacturerService
            .GetAllAsync()
            .GetAwaiter()
            .GetResult()
            .ToList();

        var manufacturerMenu = new SelectManufacturerMenu(manufacturers);
        manufacturerMenu.Start();

        var selectedManufacturer = manufacturerMenu.SelectedManufacturer;
        if (selectedManufacturer == null)
        {
            Invalid();
            return;
        }

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            Price = price.Value,
            QtyInStock = qtyInStock.Value,
            ManufacturerId = selectedManufacturer.Id,
            SubCategoryId = selectedSubCategory.Id
        };
        //Temporär för är osäker på vart produkten ska skapas, productservice?
        Console.WriteLine("Product created successfully!");
        Console.ReadKey();
          
    }

    private void Invalid()
    {
        Console.WriteLine("Invalid input. Press any key...");
        Console.ReadKey();
    }

    private int? ReadInt(string text)
    {
        Console.Write($"{text}: ");
        return int.TryParse(Console.ReadLine(), out var value) ? value : null;
    }

    private decimal? ReadDecimal(string text)
    {
        Console.Write($"{text}: ");
        return decimal.TryParse(Console.ReadLine(), out var value) ? value : null;
    }

    private string? ReadString(string text)
    {
        Console.Write($"{text}: ");
        var input = Console.ReadLine();
        return string.IsNullOrWhiteSpace(input) ? null : input;
    }
}