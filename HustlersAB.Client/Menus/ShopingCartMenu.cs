using HustlersAB.Shared.Menus;

namespace HustlersAB.Client.Menus;

public class ShopingCartMenu : BaseMenu
{
    protected override string[] Options => [];

    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                Console.WriteLine("Browsing products");
                return false;

            default:
                break;
        }
        return true;
    }
}
