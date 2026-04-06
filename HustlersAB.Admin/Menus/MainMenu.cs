namespace HustlersAB.Admin.Menus;

public class MainMenu : MenuBase
{
    public MainMenu()
    {
        _options = new[] { "Kund", "Admin", "Avsluta" };
    }

    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                new CustomerMenu().ShowMenu("Kund Meny");
                return false;

            case 1:
                new AdminMenu().ShowMenu("Admin Meny");
                return false;

            case 2:
                Environment.Exit(0);
                return true;
        }

        return false;
    }
}
