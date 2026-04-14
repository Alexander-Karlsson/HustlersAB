using Entities;
using HustlersAB.Shared.Menus;
using Services.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace HustlersAB.Admin.Menus;

public class StockMenu(IProductService productService) : BaseMenu
{
    protected override string[] Options => 
        [
        "Show Product Stock",
        "Update Product Stock",
        "Go Back"
        ];

    protected override string MenuTitle => "menu -> admin -> STOCK";

    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                ShowStock();
                break;
            case 1:
                UpdateStock();
                break;
            case 2:
                return true;
        }
        return false;
    }
    private void ShowStock()
    {
        Header("PRODUCT STOCK");

        var products = GetProducts();
        if (products == null)
            return;

        PrintProducts(products);
        Pause();
    }
    private void UpdateStock()
    {
        Header("UPDATE STOCK");

        var products = GetProducts();
        if (products == null)
            return;

        PrintProducts(products);

        Console.Write("Choose product number: ");
        if (!int.TryParse(Console.ReadLine(), out int choice) ||
            choice < 0 || choice >= products.Count)
        {
            Invalid();
            return;
        }

        var selectedProduct = products[choice];

        Console.WriteLine($"New stock value ({selectedProduct.QtyInStock}): ");
        if (!int.TryParse(Console.ReadLine(), out int newStock) || newStock < 0)
        {
            Invalid();
            return;
        }

        selectedProduct.QtyInStock = newStock;
        productService.UpdateAsync(selectedProduct).GetAwaiter().GetResult();

        Header("STOCK UPDATED");
        Console.WriteLine($"Name: {selectedProduct.Name}");
        Console.WriteLine($"New stock: {selectedProduct.QtyInStock}");
        Pause();
    }

    private List<Product>? GetProducts()
    {
        var products = productService
            .GetAllAsync()
            .GetAwaiter()
            .GetResult()
            .ToList();

        if (!products.Any())
        {
            Pause("No products found... Press any key.");
            return null;
        }
        return products;
    }

    private void PrintProducts(List<Product> products)
    {
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i}. {products[i].Name} - Stock: {products[i].QtyInStock}");
        }
    }
}
