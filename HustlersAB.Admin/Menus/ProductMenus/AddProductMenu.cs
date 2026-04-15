using Entities;
using HustlersAB.Shared.Menus;
using Services.Interfaces.Categories;
using Services.Interfaces.Manufacturers;
using Services.Interfaces.Products;

namespace HustlersAB.Admin.Menus;

public class AddProductMenu(
    IProductSubCategoryService subCategoryService, 
    IManufacturerService manufacturerService,
    IProductService productService) : BaseMenu
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
        Header("CREATE PRODUCT");
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

        var selectedManufacturer = SelectManufacturer();
        var selectedSubcategory = SelectSubCategory();
        if (selectedManufacturer == null || selectedSubcategory == null)
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
            SubCategoryId = selectedSubcategory.Id
        };
        
        productService.CreateAsync(product).GetAwaiter().GetResult();

        Header("Product created successfully!");
        Console.WriteLine($"Name: {product.Name} | Price: {product.Price}");
        Console.WriteLine($"Description: {product.Description}");
        Console.WriteLine($"Quantity in stock: {product.QtyInStock}");
        Console.WriteLine($"Subcategory: {selectedSubcategory.Name}");
        Console.WriteLine($"Manufacturer: {selectedManufacturer.Name}");
        Pause();
    }
    private ProductSubCategory? SelectSubCategory()
    {
        Console.Clear();

        var subCategories = subCategoryService
            .GetAllAsync()
            .GetAwaiter()
            .GetResult()
            .ToList();

        var subCategoryMenu = new SelectSubCategoryMenu(subCategories);
        subCategoryMenu.Start();

        return subCategoryMenu.SelectedSubCategory;
    }

    private Manufacturer? SelectManufacturer()
    {
        Console.Clear();

        var manufacturers = manufacturerService
            .GetAllAsync()
            .GetAwaiter()
            .GetResult()
            .ToList();

        var manufacturerMenu = new SelectManufacturerMenu(manufacturers);
        manufacturerMenu.Start();

        return manufacturerMenu.SelectedManufacturer;
    }
}