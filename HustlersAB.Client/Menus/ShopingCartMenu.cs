using Entities;
using HustlersAB.Shared;
using HustlersAB.Shared.Menus;
using System.Linq;

namespace HustlersAB.Client.Menus;

public class ShopingCartMenu : BaseMenu
{
    private readonly Cart _cart;

    public ShopingCartMenu(Cart cart)
    {
        _cart = cart;
    }

    protected override string[] Options
    {
        get
        {
            var items = _cart.Items.ToList();
            if (items.Count == 0)
            {
                return new string[] { "Cart is empty", "Back" };
            }

            var names = items.ConvertAll(p => p.Name);
            names.Add($"View total: {_cart.Total:C}");
            names.Add("Back");
            return names.ToArray();
        }
    }

    protected override bool ExecuteChoice(int selectedIndex)
    {
        var items = _cart.Items.ToList();

        if (items.Count == 0)
        {
            if (selectedIndex == 1)
                return true;
            return false;
        }

        if (selectedIndex < items.Count)
        {
            var product = items[selectedIndex];
            Console.Clear();
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Description: {product.Description}");
            Console.WriteLine($"Price: {product.Price:C}");
            Console.WriteLine($"In stock: {product.QtyInStock}");
            Console.WriteLine();
            Console.WriteLine("A = Add one more to cart");
            Console.WriteLine("R = Remove this item from cart");
            Console.WriteLine("B = Back");
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.A:
                    _cart.Add(product);
                    Console.WriteLine("\nAdded one more to cart.");
                    break;
                case ConsoleKey.R:
                    _cart.Remove(product);
                    Console.WriteLine("\nRemoved item from cart.");
                    break;
                default:
                    // Back or any other key
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            return false;
        }

        // View total or Back
        var viewTotalIndex = items.Count;
        var backIndex = items.Count + 1;

        if (selectedIndex == viewTotalIndex)
        {
            Console.Clear();
            Console.WriteLine($"Cart total: {_cart.Total:C}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            return false;
        }

        if (selectedIndex == backIndex)
            return true;

        return false;
    }
}
