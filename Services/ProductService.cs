using Entities;
using Services.Interfaces;

namespace Services;

public class ProductService(IProductRepository repo) : IProductService
{
    public Task AddProductAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProductAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetProductByCategoryAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetProductByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetProductsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> SearchProductAsync(string searchTerm)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProductAsync(Product product)
    {
        throw new NotImplementedException();
    }
}