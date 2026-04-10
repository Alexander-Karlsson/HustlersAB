using Entities;
using HustlersAB.Shared.Menus;

namespace HustlersAB.Admin.Menus;

public class SelectSubCategoryMenu(List<ProductSubCategory> subCategories) : BaseMenu
{
    private readonly List<ProductSubCategory> _subCategories = subCategories.ToList();

    public ProductSubCategory? SelectedSubCategory { get; set; }
    protected override string[] Options => subCategories
        .Select(psc => psc.Name)
        .ToArray();

    protected override string MenuTitle => "menu -> admin -> SELECT SUBCATEGORY";

    protected override bool ExecuteChoice(int selectedIndex)
    {
        if (selectedIndex == subCategories.Count)
            return true;

        SelectedSubCategory = subCategories[selectedIndex];
        return true;
    }
}
