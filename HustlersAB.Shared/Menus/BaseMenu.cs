namespace HustlersAB.Shared.Menus;

public abstract class BaseMenu
{
        protected int SelectedIndex { get; set; } = 0;
        
        protected abstract string[] Options { get; }
        
        protected virtual string MenuTitle => "MENU";

        
        protected abstract bool ExecuteChoice(int selectedIndex);

        
        public void Start()
        {
            bool exitMenu = false;
            while (!exitMenu)
            {
                PrintMenu($"{MenuTitle}");
                // Console.Clear();

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Escape)
                {
                    exitMenu = true;
                    continue;
                }
                
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        SelectedIndex = (SelectedIndex - 1 + Options.Length) % Options.Length;
                        break;

                    case ConsoleKey.DownArrow:
                        SelectedIndex = (SelectedIndex + 1) % Options.Length;
                        break;

                    case ConsoleKey.Enter:
                        exitMenu = ExecuteChoice(SelectedIndex);
                        break;
                }
            }
        }
        
        private void PrintMenu(string menuPath)
        {
            Console.Clear();
            Console.WriteLine(".....::::: HUSTLERS AB :::::.....\n");
            Console.WriteLine($"{menuPath}\n");
            
            for (int i = 0; i < Options.Length; i++)
            {
                if (i == SelectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Options[i]} <-");
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine(Options[i]);
                }
            }

            Console.ResetColor();
            Console.WriteLine("\nUse ↑/↓ to navigate, Enter to select, Esc to exit");
        }
    public static void Invalid()
    {
        Console.WriteLine("Invalid input. Press any key...");
        Console.ReadKey();
    }

}