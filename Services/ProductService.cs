using Entities;
using Services.Interfaces;

namespace Services;

public class ProductService(IProductRepository repo) : IProductService
{
    public async Task<List<Product>> GetProductsAsync()
    {
        var products = await repo.GetAllAsync();

        return products.Take(3).ToList();
    }
}