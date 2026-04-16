using Entities;
using HustlersAB.Shared.Menus;
using Services.Interfaces.Payment;
using Services.Interfaces.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HustlersAB.Client.Menus;

public class CheckoutMenu(PaymentMenu paymentMenu, Cart cart, IShippingService shippingService) : BaseMenu
{
    private List<Shipping> _shippings = shippingService
        .GetShippingAsync()
        .GetAwaiter()
        .GetResult()
        .ToList();
    private Shipping? _selectedShipping;

    protected override string[] Options
    {
        get
        {
            var options = new List<string>();

            if (_shippings.Count == 0)
            {
                options.Add("No shipping options available");
            }
            else
            {
                for (int i = 0; i < _shippings.Count; i++)
                {
                    var s = _shippings[i];
                    var sel = _selectedShipping != null && _selectedShipping.Id == s.Id ? " (selected)" : string.Empty;
                    options.Add($"{s.TypeOfShipping}: {s.Price:C}" + sel);
                }
            }

            options.Add($"Cart total: {cart.Total:C}");
            options.Add($"Total (with shipping): {cart.Total + (_selectedShipping?.Price ?? 0m):C}");
            options.Add("Proceed to payment");
            options.Add("Back");

            return options.ToArray();
        }
    }

    protected override string MenuTitle => "CHECKOUT";

    protected override bool ExecuteChoice(int selectedIndex)
    {
        // If user selects one of the shipping alternatives
        if (_shippings.Count > 0 && selectedIndex < _shippings.Count)
        {
            _selectedShipping = _shippings[selectedIndex];
            var shippingPrice = _selectedShipping.Price;
            var grandTotal = cart.Total + shippingPrice;
            Console.Clear();
            Console.WriteLine($"Selected: {_selectedShipping.TypeOfShipping} - {_selectedShipping.Price:C}");
            Console.WriteLine();
            Console.WriteLine($"Cart total: {cart.Total:C}");
            Console.WriteLine($"Shipping: {shippingPrice:C}");
            Console.WriteLine($"Grand total: {grandTotal:C}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            return false; // stay in this menu
        }

        int shippingCount = _shippings.Count;
        int viewCartIndex = shippingCount; // Cart total
        int totalWithShippingIndex = shippingCount + 1;
        int proceedIndex = shippingCount + 2;
        int backIndex = shippingCount + 3;

        if (selectedIndex == viewCartIndex || selectedIndex == totalWithShippingIndex)
        {
            var shippingPrice = _selectedShipping?.Price ?? 0m;
            var grandTotal = cart.Total + shippingPrice;
            Console.Clear();
            Console.WriteLine($"Cart total: {cart.Total:C}");
            Console.WriteLine($"Shipping: {shippingPrice:C}");
            Console.WriteLine($"Grand total: {grandTotal:C}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            return false;
        }

            if (selectedIndex == proceedIndex)
        {
            if (_selectedShipping == null)
            {
                Console.Clear();
                Console.WriteLine("Please select a shipping option before proceeding.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                return false;
            }

            paymentMenu.Configure(_selectedShipping);
            paymentMenu.Start();
            return true; // return to caller so it can navigate forward
        }

        if (selectedIndex == backIndex)
            return true;

        return false;
    }
}
