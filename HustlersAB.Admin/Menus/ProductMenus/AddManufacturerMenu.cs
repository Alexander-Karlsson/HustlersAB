using Entities;
using HustlersAB.Shared.Menus;
using Services.Interfaces.Manufacturers;

namespace HustlersAB.Admin.Menus.ProductMenus;

public class AddManufacturerMenu(IManufacturerService manufacturerService) : BaseMenu
{
    protected override string MenuTitle => "ADD MANUFACTURER";
    protected override string[] Options =>
        [
        "Add manufacturer",
        "Delete manufacturer",
        "Update manufacturer",
        "Go Back"
        ];

    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                AddManufacturer();
                break;
            case 1:
                DeleteManufacturer();
                break;
            case 2:
                UpdateManufacturer();
                break;
            case 3:
                return true;
        }
        return false;
    }

    private void UpdateManufacturer()
    {
        Header("UPDATE MANUFACTURER");

        var manufacturers = manufacturerService
            .GetAllAsync()
            .GetAwaiter()
            .GetResult()
            .ToList();

        if (!manufacturers.Any())
        {
            Pause("No manufaturer found.");
            return;
        }

        for (int i = 0; i < manufacturers.Count; i++)
        {
            Console.WriteLine($"{i}. {manufacturers[i].Name}");
        }

        var choice = ReadInt("Choose manufacturer number to update");

        if (choice == null || choice < 0 || choice >= manufacturers.Count)
        {
            Invalid();
            return;
        }

        var selectedManufacturer = manufacturers[choice.Value];

        EditManufacturer(selectedManufacturer);
        SaveManufacturer(selectedManufacturer);

    }

    private void EditManufacturer(Manufacturer selectedManufacturer)
    {
        Header("EDIT MANUFACTURER");
        Console.WriteLine("Leave empty to keep current value.");
        Console.WriteLine();

        selectedManufacturer.Name = ReadUpdatedString("Name", selectedManufacturer.Name);
    }
    private void SaveManufacturer(Manufacturer selectedManufacturer)
    {
        manufacturerService.UpdateAsync(selectedManufacturer)
            .GetAwaiter()
            .GetResult();

        Console.WriteLine("Manufacturer updated successfully!");
        Console.WriteLine();
        Console.WriteLine($"Name: {selectedManufacturer.Name}");
    }

    

    private void DeleteManufacturer()
    {
        throw new NotImplementedException();
    }

    private void AddManufacturer()
    {
        Header("ADD MANUFACTURER");

        var name = ReadString("Enter manufacturer name");

        if (name == null)
        {
            Invalid();
            return;
        }

        var manufacturer = new Manufacturer
        {
            Id = Guid.NewGuid(),
            Name = name
        };

        manufacturerService.CreateAsync(manufacturer).GetAwaiter().GetResult();

        Header("MANUFACTURER CREATED");
        Console.WriteLine($"Name: {manufacturer.Name}");
        Pause();
    }
}
