using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using HustlersAB.Admin.Menus;
using Services.Interfaces.Products;

namespace HustlersAB.Client;

public class StartPage(IProductService productService, IQuoteService quoteService, AdminMenu adminMenu)
{
    private readonly AdminMenu _adminMenu = adminMenu;

    public async Task Show()
    {
        Console.Clear();
        Console.WriteLine("=== Welcome to Hustlers AB ===");
        Console.WriteLine("Our top three products:");

        var products = await productService.GetStartPageProductsAsync();
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Name} | {p.Price}kr");
        }
        Console.WriteLine();

        var quote = await quoteService.GetQuoteAsync();

        if (quote != null)
        {
            Console.WriteLine($"Quote of the day: {quote.q} | {quote.a}");
        }
        Console.WriteLine();

        Console.WriteLine("Press any key to continue");
        Console.ReadKey(true);
    }
}
