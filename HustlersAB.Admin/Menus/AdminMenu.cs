namespace HustlersAB.Admin.Menus;

public class AdminMenu : MenuBase
{
    public AdminMenu()
    {
        _options = new[]
        {
            "Administrera produkter",
            "Administrera kategorier",
            "Administrera kunder",
            "Se statistik",
            "Tillbaka"
        };
    }

    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                Console.Clear();
                Console.WriteLine("Produktadministration kommer senare...");
                Console.ReadKey(true);
                return false;

            case 1:
                Console.Clear();
                Console.WriteLine("Kategoriadministration kommer senare...");
                Console.ReadKey(true);
                return false;

            case 2:
                Console.Clear();
                Console.WriteLine("Kundadministration kommer senare...");
                Console.ReadKey(true);
                return false;

            case 3:
                Console.Clear();
                Console.WriteLine("Statistik kommer senare...");
                Console.ReadKey(true);
                return false;

            case 4:
                return true;
        }

        return false;
    }
}
