using Entities;
using HustlersAB.Shared.Menus;
using System;
using System.Collections.Generic;
using System.Text;

namespace HustlersAB.Client.Menus;

public class CheckoutMenu(Cart cart) : BaseMenu
{
    private readonly Cart _cart = cart;
    protected override string[] Options
    {
        get
        {
            var items = _cart.Items.ToList();
            var names = items.ConvertAll(p => p.Name + ": " + p.Price + " Kr");
            names.Add($"View total: {_cart.Total:C}");
            names.Add("Back");
            return names.ToArray();
        }
    }
    protected override string MenuTitle => "CHECKOUT";

    protected override bool ExecuteChoice(int selectedIndex)
    {
        var items = _cart.Items.ToList();

        if (items.Count == 0)
        {
            if (selectedIndex == 1)
                return true;
            return false;
        }

        // View total or Back
        var viewTotalIndex = items.Count;
        var backIndex = items.Count + 1;
        var checkoutIndex = items.Count + 2;

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

        if (selectedIndex == checkoutIndex)
        { return true; }


        return false;
    }
}
