using Entities;
using Services.Interfaces.Products;

namespace HustlersAB.Admin;

public class MenuHelper(IProductService productService)
{
    public List<Product> GetProducts()
    {
        return productService
        .GetAllAsync()
        .GetAwaiter()
        .GetResult()
        .ToList();
    }

    public void ProductLoop(List<Product> products)
    {
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i}. {products[i].Name} - {products[i].Price}");
        }
    }
}
