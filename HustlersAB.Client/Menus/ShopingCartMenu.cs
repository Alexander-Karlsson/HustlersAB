using Entities;
using HustlersAB.Shared;
using HustlersAB.Shared.Menus;
using Services;
using Services.Interfaces.Payment;
using Services.Interfaces.Shipping;
using System.Linq;

namespace HustlersAB.Client.Menus;

public class ShopingCartMenu(CheckoutMenu checkoutMenu, Cart cart) : BaseMenu
{
    protected override string[] Options
    {
        get
        {
            var items = cart.Items.ToList();
            if (items.Count == 0)
            {
                return new string[] { "Cart is empty", "Back" };
            }

            var names = items.ConvertAll(p => p.Name +": " + p.Price + " Kr");
            names.Add($"View total: {cart.Total:C}");
            names.Add("Back");
            names.Add("Go to Checkout");
            return names.ToArray();
        }
    }

    protected override string MenuTitle => "CART";

    protected override bool ExecuteChoice(int selectedIndex)
    {
        var items = cart.Items.ToList();

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
                    cart.Add(product);
                    Console.WriteLine("\nAdded one more to cart.");
                    break;
                case ConsoleKey.R:
                    cart.Remove(product);
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
        var checkoutIndex = items.Count + 2;

        if (selectedIndex == viewTotalIndex)
        {
            Console.Clear();
            Console.WriteLine($"Cart total: {cart.Total:C}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            return false;
        }

        if (selectedIndex == backIndex)
            return true;

        if (selectedIndex == checkoutIndex)
        {
            checkoutMenu.Start();
        }

        return false;
    }
}