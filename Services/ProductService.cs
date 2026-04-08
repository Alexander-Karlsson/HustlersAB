using Entities;
using Services.Interfaces;

namespace Services;

public class ProductService(IProductRepository repo) : IProductService
{
    public async Task<IEnumerable<Product>> GetStartPageProductsAsync()
    {
        return await repo.GetStartPageProductsAsync();
    }
}