using Entities;
using HustlersAB.Shared.Menus;
using Services.Interfaces.Categories;

namespace HustlersAB.Admin.Menus.ProductMenus;

public class ManageSubCategory(IProductCategoryService productCategoryService,
    IProductSubCategoryService productSubCategoryService) : BaseMenu
{
    protected override string[] Options => 
        [
        "Add SubCategory",
        "Update SubCategory",
        "Delete SubCategory",
        "Go Back"
        ];

    protected override string MenuTitle => "menu -> admin -> MANAGE SUBCATEGORIES";

    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                AddSubCategory();
                break;
            case 1:
                UpdateSubCategory();
                break;
            case 2:
                DeleteSubCategory();
                break;
            case 3:
                return true;
        }
        return false;
    }

    private void DeleteSubCategory()
    {
        Header("DELETE SUBCATEGORY");

        var subCategory = SelectSubCategory();
        if (subCategory == null)
            return;

        if (!ConfirmDelete(subCategory.Name))
            return;

        productSubCategoryService.DeleteAsync(subCategory.Id)
            .GetAwaiter()
            .GetResult();

        Console.WriteLine("SubCategory deleted successfully!");
        Pause();
    }

    private void UpdateSubCategory()
    {
        Header("UPDATE SUBCATEGORY");

        var subCategory = SelectSubCategory();
        if (subCategory == null)
            return;

        subCategory.Name = ReadUpdatedString("Name", subCategory.Name);

        if (Change("Change parent category? Y/N: "))
        {
            var category = SelectCategory();
            if (category == null)
                return;

            subCategory.ParentCategoryId = category.Id;
        }

        productSubCategoryService.UpdateAsync(subCategory)
            .GetAwaiter()
            .GetResult();

        Console.WriteLine("SubCategory updated successfully!");
        Console.WriteLine($"Name: {subCategory.Name}");
        Pause();
    }

    private void AddSubCategory()
    {
        Header("ADD SUBCATEGORY");

        var name = ReadString("Enter subcategory name: ");

        if (name == null)
        {
            Invalid();
            return;
        }

        var category = SelectCategory();
        if (category == null)
        {
            Invalid();
            return;
        }

        var subCategory = new ProductSubCategory
        {
            Id = Guid.NewGuid(),
            Name = name,
            ParentCategoryId = category.Id
        };

        productSubCategoryService.CreateAsync(subCategory)
            .GetAwaiter()
            .GetResult();

        Header("SUBCATEGORY CREATED");
        Console.WriteLine($"Name: {subCategory.Name}");
        Console.WriteLine($"Category: {category.Name}");
        Pause();
    }


    private ProductSubCategory? SelectSubCategory()
    {
        var subCategories = productSubCategoryService
            .GetAllAsync()
            .GetAwaiter()
            .GetResult()
            .ToList();
        if (!subCategories.Any())
        {
            Pause("No categories found.");
            return null;
        }

        for (int i = 0; i < subCategories.Count; i++)
        {
            Console.WriteLine($"{i}. {subCategories[i].Name}");
        }

        var choice = ReadInt("Choose parent category");
        if (choice == null || choice < 0 || choice >= subCategories.Count)
        {
            Invalid();
            return null;
        }
        return subCategories[choice.Value];
    }
    private ProductCategory? SelectCategory()
    {
        var categories = productCategoryService
            .GetAllAsync()
            .GetAwaiter()
            .GetResult()
            .ToList();

        if (!categories.Any())
        {
            Pause("No categories found.");
            return null;
        }

        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine($"{i}. {categories[i].Name}");
        }

        var choice = ReadInt("Choose category");
        if (choice == null || choice < 0 || choice >= categories.Count)
        {
            Invalid();
            return null;
        }

        return categories[choice.Value];
    }
    private bool Change(string message)
    {
        Console.Write(message);
        return Console.ReadLine()?.Trim().ToLower() == "y";
    }

}
