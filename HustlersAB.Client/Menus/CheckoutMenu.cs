using Entities;
using HustlersAB.Shared.Menus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HustlersAB.Client.Menus;

public class CheckoutMenu(Cart cart, IEnumerable<Shipping> shippings) : BaseMenu
{
    private readonly Cart _cart = cart;
    private readonly List<Shipping> _shippings = shippings?.ToList() ?? new();

    protected override string[] Options
    {
        get
        {
            var options = new List<string>();

            if (_shippings.Count == 0)
                options.Add("No shipping options");
            else
                options.AddRange(_shippings.Select(s => $"{s.TypeOfShipping}: {s.Price} Kr"));

            options.Add($"View total: {_cart.Total:C}");
            options.Add("Confirm");
            options.Add("Back");

            return options.ToArray();
        }
    }

    protected override string MenuTitle => "CHECKOUT";

    protected override bool ExecuteChoice(int selectedIndex)
    {
        // selecting a shipping option
        if (_shippings.Count > 0 && selectedIndex < _shippings.Count)
        {
            var sel = _shippings[selectedIndex];
            Console.Clear();
            Console.WriteLine($"Selected: {sel.TypeOfShipping} - {sel.Price:C}");
            Console.WriteLine("Press any key...");
            Console.ReadKey(true);
            return false;
        }

        // View total = index after shipping options (or 0 if none)
        int viewTotalIndex = Math.Max(0, _shippings.Count);
        if (selectedIndex == viewTotalIndex)
        {
            var shippingPrice = 0m;
            Console.Clear();
            Console.WriteLine($"Cart total: {_cart.Total:C}");
            Console.WriteLine("Press any key...");
            Console.ReadKey(true);
            return false;
        }

        // Confirm and Back handling (adjust indices if needed)
        // ...
        return true;
    }
}
