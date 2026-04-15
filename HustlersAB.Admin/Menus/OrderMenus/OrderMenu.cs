using Entities;
using HustlersAB.Shared.Menus;
using Services.Interfaces.Customers;
using Services.Interfaces.Orders;
using Services.Interfaces.Payment;
using Services.Interfaces.Products;
using Services.Interfaces.Shipping;

namespace HustlersAB.Admin.Menus.OrderMenus;

public class OrderMenu(
    IOrderService orderService,
    ICustomerService customerService,
    IShippingService shippingService,
    IProductService productService,
    IPaymentMethodService paymentService) : BaseMenu
{
    protected override string[] Options =>
    [
        "Add Order",
        "Search Order(s)",
        "Update Order",
        "Delete Order",
        "Go Back"
    ];

    protected override string MenuTitle => "menu -> admin -> MANAGE ORDERS";

    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0: AddOrder(); break;
            case 1: SearchOrders(); break;
            case 2: UpdateOrder(); break;
            case 3: DeleteOrder(); break;
            case 4: return true;
        }
        return false;
    }
    
    // Crud metoder
    
    private void AddOrder()
    {
        Header("ADD NEW ORDER");

        var customers = customerService.GetAllAsync().GetAwaiter().GetResult().ToList();
        var customer = PromptSelect(customers, c => c.Name, "customer");
        if (customer is null) return;

        var shippings = shippingService.GetShippingAsync().GetAwaiter().GetResult().ToList();
        var shipping = PromptSelect(shippings, s => $"{s.TypeOfShipping} ({s.Price:C})", "shipping");
        if (shipping is null) return;

        var paymentMethods = paymentService.GetPaymentMethodAsync().GetAwaiter().GetResult().ToList();
        var paymentMethod = PromptSelect(paymentMethods, pm => pm.PaymentName, "payment method" );
        if(paymentMethod is null) return;
        

        var products = productService.GetAllAsync().GetAwaiter().GetResult().ToList();
        var productOrders = PickProducts(products);
        if (!productOrders.Any())
        {
            Pause("No products selected. Order cancelled.");
            return;
        }

        var productTotal = productOrders
            .Sum(po => po.Quantity * products.First(p => p.Id == po.ProductId).Price);

        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = customer.Id,
            ShippingId = shipping.Id,
            PaymentMethodId = paymentMethod.Id,
            OrderDate = DateTime.Now,
            TotalPrice = productTotal + shipping.Price,
            ProductOrders = productOrders
        };

        orderService.CreateAsync(order).GetAwaiter().GetResult();

        Console.Clear();
        Header("Order created successfully!");
        Console.WriteLine($"Customer:  {customer.Name}");
        Console.WriteLine($"Shipping:  {shipping.TypeOfShipping} ({shipping.Price:C})");
        Console.WriteLine($"Date:      {order.OrderDate:d}");
        Console.WriteLine($"Total:     {order.TotalPrice:C}");
        Console.WriteLine("-----------------------------");
        Console.ReadKey();
    }

    private void SearchOrders()
    {
        Header("SEARCH ORDERS");
        var query = ReadString(">");
        if (query is null) { Pause(); return; }

        var orders = orderService.GetBySearchAsync(query).GetAwaiter().GetResult().ToList();

        if (!orders.Any())
        {
            Console.WriteLine($"No orders found for: {query}");
            Pause();
            return;
        }

        Header($"Results for: {query}");
        PrintOrderList(orders);
        Pause();
    }

    private void UpdateOrder()
    {
        Header("UPDATE ORDER");
        var selected = PromptSelectOrder();
        if (selected is null) return;

        Console.Clear();
        Console.WriteLine($"Updating order for: {selected.Customer.Name} ({selected.OrderDate:d})");
        Console.WriteLine("Press Enter to keep current value.\n");

        var shippings = shippingService.GetShippingAsync().GetAwaiter().GetResult().ToList();
        var newShipping = PromptSelect(shippings, s => $"{s.TypeOfShipping} ({s.Price:C})", "shipping");
        if (newShipping is not null)
            selected.ShippingId = newShipping.Id;

        orderService.UpdateAsync(selected).GetAwaiter().GetResult();
        Pause("Order updated successfully.");
    }

    private void DeleteOrder()
    {
        Header("DELETE ORDER");
        var selected = PromptSelectOrder();
        if (selected is null) return;

        if (!ConfirmDelete($"order for {selected.Customer.Name} ({selected.OrderDate:d})"))
        {
            Pause("Deletion cancelled.");
            return;
        }

        orderService.DeleteAsync(selected.Id).GetAwaiter().GetResult();
        Pause("Order deleted successfully.");
    }

    // Fina helpersa

    private List<ProductOrder> PickProducts(List<Product> products)
    {
        var productOrders = new List<ProductOrder>();

        while (true)
        {
            Console.Clear();
            Header("ADD PRODUCTS");

            if (productOrders.Any())
            {
                Console.WriteLine("Current items:");
                foreach (var po in productOrders)
                {
                    var p = products.First(x => x.Id == po.ProductId);
                    Console.WriteLine($"  {p.Name} x{po.Quantity} = {po.Quantity * p.Price:C}");
                }
                Console.WriteLine();
            }

            var product = PromptSelect(products, p => $"{p.Name} - {p.Price:C} (stock: {p.QtyInStock})", "product");
            if (product is null) break;

            var qty = ReadInt("Quantity");
            if (qty is null || qty < 1) { Invalid(); continue; }

            var existing = productOrders.FirstOrDefault(po => po.ProductId == product.Id);
            if (existing is not null)
                existing.Quantity += (int)qty;
            else
                productOrders.Add(new ProductOrder
                {
                    Id = Guid.NewGuid(),
                    ProductId = product.Id,
                    Quantity = (int)qty
                });

            Console.Write("\nAdd more products? (y/n): ");
            if (Console.ReadLine()?.Trim().ToLower() != "y") break;
        }

        return productOrders;
    }

    private Order? PromptSelectOrder()
    {
        var orders = orderService.GetAllAsync().GetAwaiter().GetResult().ToList();

        if (!orders.Any())
        {
            Pause("No orders found.");
            return null;
        }

        PrintOrderList(orders);

        var choice = ReadInt("Choose order number");
        if (choice is null || choice < 1 || choice > orders.Count)
        {
            Invalid();
            return null;
        }

        return orders[(int)choice - 1];
    }
    private T? PromptSelect<T>(List<T> items, Func<T, string> label, string name) where T : class
    {
        if (!items.Any()) { Pause($"No {name}s found."); return null; }

        var count = 0;
        foreach (var item in items)
            Console.WriteLine($"{++count}. {label(item)}");

        var choice = ReadInt($"Select {name}");
        if (choice is null || choice < 1 || choice > items.Count) { Invalid(); return null; }

        return items[(int)choice - 1];
    }

    private void PrintOrderList(List<Order> orders)
    {
        var count = 0;
        foreach (var o in orders)
            Console.WriteLine($"{++count}. {o.Customer.Name} | {o.OrderDate:d} | {o.TotalPrice:C} | {o.Shipping?.TypeOfShipping}");
    }
}