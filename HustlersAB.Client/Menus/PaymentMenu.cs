using Entities;
using HustlersAB.Shared.Menus;
using Services.Interfaces.Payment;

namespace HustlersAB.Client.Menus;

public class PaymentMenu(IPaymentMethodService paymentMethodService, Cart cart, Shipping? selectedShipping) : BaseMenu
{
    private PaymentMethod? _selectedPayment;
    private readonly Cart _cart = cart;
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
            var grandTotal = _cart.Total + shippingPrice;

            Console.Clear();
            Console.WriteLine($"Selected payment: {_selectedPayment.PaymentName}");
            Console.WriteLine();
            Console.WriteLine($"Cart total: {_cart.Total:C}");
            Console.WriteLine($"Shipping: {shippingPrice:C}");
            Console.WriteLine($"Grand total: {grandTotal:C}");
            Console.WriteLine();
            Console.WriteLine("Press 'C' to confirm purchase, any other key to return...");
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.C)
            {
                new ReceiptMenu(_cart, _selectedShipping, _selectedPayment).Start();
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
