using Entities;
using HustlersAB.Shared.Menus;

namespace HustlersAB.Admin.Menus;

public class SelectManufacturerMenu(IEnumerable<Manufacturer> manufacturers) : BaseMenu
{
    private readonly List<Manufacturer> _manufacturers = manufacturers.ToList();

    public Manufacturer? SelectedManufacturer { get; set; }
    protected override string[] Options => 
        _manufacturers.Select(m => m.Name)
        .ToArray();

    protected override string MenuTitle => "menu -> admin -> SELECT MANUFACTURER";

    protected override bool ExecuteChoice(int selectedIndex)
    {
        if (selectedIndex == _manufacturers.Count)
            return true;

        SelectedManufacturer = _manufacturers[selectedIndex];
        return true;
    }
}
