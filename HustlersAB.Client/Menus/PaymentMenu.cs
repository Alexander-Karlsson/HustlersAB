using Entities;
using HustlersAB.Shared.Menus;
using Services.Interfaces.Customers;
using Services.Interfaces.Orders;
using Services.Interfaces.Payment;
using Services.Interfaces.Shipping;

namespace HustlersAB.Client.Menus;

public class PaymentMenu(
    IPaymentMethodService paymentMethodService, 
    ICustomerService customerService, 
    IOrderService orderService, 
    Cart cart) : BaseMenu
{
    private List<PaymentMethod> _paymentMethods = Array.Empty<PaymentMethod>().ToList();
    private Shipping? _selectedShipping;

    public void Configure(Shipping? selectedShipping)
    {
        _selectedShipping = selectedShipping;
    }

    public void LoadData()
    {
        _paymentMethods = paymentMethodService
            .GetPaymentMethodAsync()
            .GetAwaiter()
            .GetResult()
            .ToList();
    }

    public void Start()
    {
        LoadData();
        base.Start(); // or show menu logic that uses _selectedShipping
    }

    private PaymentMethod? _selectedPayment;
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
            var Moms = (cart.Total) * 0.25m;
            var grandTotal = cart.Total + shippingPrice + Moms;
            
            Console.Write("Enter a Name: "); var customerName = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter an email: "); var customerEmail = Console.ReadLine() ?? string.Empty; 
            Console.Write("Enter an phone: "); var customerPhone = Console.ReadLine() ?? string.Empty; 
            Console.Write("Enter an address: "); var customerAddress = Console.ReadLine() ?? string.Empty; 
            Console.Write("Enter an postal number: "); var customerPostalNumber = Console.ReadLine() ?? string.Empty; 

            var customer = new Customer { Id = Guid.NewGuid(), Name = customerName, IsMember = false};
            var customerContactInfo = new CustomerContactInfo 
            { Id = Guid.NewGuid(), 
                Email = customerEmail, 
                Phone = customerPhone, 
                Address = customerAddress,
                PostalNumber = customerPostalNumber,
                CustomerId = customer.Id };

            customerService.CreateAsync(customer, customerContactInfo).GetAwaiter().GetResult();

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
                var order = new Order 
                { Id = Guid.NewGuid(), 
                    CustomerId = customer.Id, 
                    ShippingId = _selectedShipping!.Id, 
                    PaymentMethodId = _selectedPayment.Id, 
                    TotalPrice = grandTotal,
                    OrderDate = DateTime.Now,    
                };
                orderService.CreateAsync(order);
                new ReceiptMenu(cart, _selectedShipping, _selectedPayment).Start();
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