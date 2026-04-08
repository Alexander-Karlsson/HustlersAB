using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HustlersAB.Admin;

public class StartPage(IProductService productService)
{
    public async Task Show()
    {
        Console.WriteLine("=== Welcome to Hustlers AB ===");
        Console.WriteLine("Our top three products:");

        var products = await productService.GetProductsAsync();
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Name} | {p.Price}");
        }
        //Guid test => ;
        //var productsInCategory = await productService.GetByParentCategoryAsync(test);
        //foreach (var pc in productsInCategory)
        //{
        //    Console.WriteLine($"{pc.Name}");
        //}
    }
}
