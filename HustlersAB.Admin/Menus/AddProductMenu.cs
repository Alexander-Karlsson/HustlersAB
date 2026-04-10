using Entities;
using HustlersAB.Shared.Menus;
using Services.Interfaces.Categories;
using Services.Interfaces.Products;

namespace HustlersAB.Admin.Menus;

public class AddProductMenu(IProductSubCategoryService subCategoryService) : BaseMenu
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
        //Hårdkodad pga har ej manufaturer
        var manufacturerId = Guid.Parse("20000001-0000-0000-0000-000000000000");

        //Vi borde skicka till service, typ models?
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            Price = price.Value,
            QtyInStock = qtyInStock.Value,
            ManufacturerId = manufacturerId,
            //ManufacturerId = selectedManufacturer.Id,
            SubCategoryId = selectedSubCategory.Id
        };
        //Temporär bara för att se så det funkar i framtiden
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