using Entities;
using HustlersAB.Shared.Menus;
using Services;
using Services.Interfaces.CustomerContactInfos;
using Services.Interfaces.Customers;
using Services.Interfaces.Orders;
using Services.Interfaces.Payment;
using Services.Interfaces.Shipping;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Text;

namespace HustlersAB.Client.Menus;

public class PaymentMenu(IPaymentMethodService paymentMethodService, Cart cart, Shipping? selectedShipping) : BaseMenu
{
    private readonly ICustomerService customerService;
    private readonly ICustomerContactInfoService customerContactInfoService;
    private readonly IOrderService orderService;
    private PaymentMethod? _selectedPayment;
    //private readonly Cart _cart = cart;
    private readonly Shipping? _selectedShipping = selectedShipping;
    private readonly List<PaymentMethod> _paymentMethods = paymentMethodService
        .GetPaymentMethodAsync()
        .GetAwaiter()
        .GetResult()
        .ToList();
    protected override string[] Options
    {
        get
        {
            var options = new List<string>();

            if (_paymentMethods.Count == 0)
            {
                options.Add("No Payment options available");
            }
            else
            {
                for (int i = 0; i < _paymentMethods.Count; i++)
                {
                    var s = _paymentMethods[i];
                    var sel = _selectedPayment != null && _selectedPayment.Id == s.Id ? " (selected)" : string.Empty;
                    options.Add($"{s.PaymentName}");
                }
            }
            options.Add($"Back");
            return options.ToArray();
        }
    }

    protected override bool ExecuteChoice(int selectedIndex)
    {
        if (_paymentMethods.Count > 0 && selectedIndex < _paymentMethods.Count)
        {
            _selectedPayment = _paymentMethods[selectedIndex];

            var shippingPrice = _selectedShipping?.Price ?? 0m;
            var Moms = (cart.Total + shippingPrice) / 4;
            var grandTotal = cart.Total + shippingPrice + Moms;

            Console.Write("Enter a Name: "); var customerName = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter an email: "); var customerEmail = Console.ReadLine() ?? string.Empty; 

            var customer = new Customer { Id = Guid.NewGuid(), Name = customerName };
            var customerContactInfo = new CustomerContactInfo { Id = Guid.NewGuid(), Email = customerEmail, CustomerId = customer.Id };

            customerService.CreateAsync(customer, customerContactInfo);
            customerContactInfoService.CreateAsync(customerContactInfo);

            Console.Clear();
            Console.WriteLine($"Selected payment: {_selectedPayment.PaymentName}");
            Console.WriteLine();
            Console.WriteLine($"Cart total: {cart.Total:C}");
            Console.WriteLine($"Shipping: {shippingPrice:C}");
            Console.WriteLine($"Moms: {Moms:C}");
            Console.WriteLine($"Grand total: {grandTotal:C}");
            Console.WriteLine();
            Console.WriteLine("Press 'C' to confirm purchase, any other key to return...");
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.C)
            {
                Console.Clear();
                Console.WriteLine("Purchase confirmed. Thank you for your order!");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                var order = new Order 
                { Id = Guid.NewGuid(), 
                    CustomerId = customer.Id, 
                    ShippingId = _selectedShipping.Id, 
                    PaymentMethodId = _selectedPayment.Id, 
                    TotalPrice = grandTotal,
                    OrderDate = DateTime.Now,    
                };
                orderService.CreateAsync(order);
                return true;
            }

            return false;
        }

        int backIndex = _paymentMethods.Count;
        if (selectedIndex == backIndex)
            return true;

        return false;
    }
}
