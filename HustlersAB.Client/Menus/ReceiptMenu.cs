using Entities;
using HustlersAB.Shared.Menus;
using System;
using System.Collections.Generic;
using System.Text;

namespace HustlersAB.Client.Menus;

public class ReceiptMenu : BaseMenu
{
    private readonly Cart _cart;
    private readonly Shipping? _shipping;
    private readonly PaymentMethod? _paymentMethod;
    private readonly Guid _orderId;
    private readonly DateTime _createdAt;

    public ReceiptMenu(Cart cart, Shipping? shipping, PaymentMethod? paymentMethod)
    {
        _cart = cart;
        _shipping = shipping;
        _paymentMethod = paymentMethod;

        _orderId = Guid.NewGuid();
        _createdAt = DateTime.Now;
    }

    protected override string MenuTitle => "RECEIPT";

    protected override string[] Options => ["Finish"];

    protected override bool ExecuteChoice(int selectedIndex)
    {
        return selectedIndex == 0;
    }

    public new void Start()
    {
        bool exitMenu = false;

        while (!exitMenu)
        {
            PrintReceipt();

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Escape)
            {
                exitMenu = true;
                continue;
            }

            if (key == ConsoleKey.Enter)
            {
                exitMenu = ExecuteChoice(SelectedIndex);
            }
        }
    }

    private void PrintReceipt()
    {
        Header("HUSTLERS AB");

        decimal shippingCost = _shipping?.Price ?? 0;
        decimal productsTotal = _cart.Total;
        decimal total = productsTotal + shippingCost;
        decimal vat = total * 0.25m;

        Console.WriteLine($"Order number: {_orderId}");
        Console.WriteLine($"Date: {_createdAt:yyyy-MM-dd HH:mm}");
        Console.WriteLine($"Payment: {_paymentMethod?.PaymentName}");
        Console.WriteLine($"Shipping: {_shipping?.TypeOfShipping}");
        Console.WriteLine();

        Console.WriteLine("Products");
        Console.WriteLine("---------------");

        var groupedProducts = _cart.Items
            .GroupBy(product => product.Name);

        foreach (var group in groupedProducts)
        {
            var product = group.First();
            int quantity = group.Count();
            decimal sum = product.Price * quantity;

            Console.WriteLine($"{product.Name}| Qty: {quantity} | Price: {product.Price:C} | Total: {sum:C}");
        }
        Console.WriteLine();

        Console.WriteLine($"Products total: {productsTotal:C}");
        Console.WriteLine($"Shipping: {shippingCost:C}");
        Console.WriteLine($"VAT (25%): {vat:C}");
        Console.WriteLine($"Total: {total:C}");
        Console.WriteLine();
        Console.WriteLine("Thank you for your purchase!\n");
        Console.WriteLine("Press Enter to finish, Esc to exit");
        _cart.Clear();
    }
}
