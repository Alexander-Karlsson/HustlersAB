using Entities;

namespace Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductsAsync();

    Task<Product?> GetProductByIdAsync(Guid id);

    Task<IEnumerable<Product>> GetProductByCategoryAsync(int categoryId);

    Task<IEnumerable<Product>> SearchProductAsync(string searchTerm);

    Task AddProductAsync(Product product);

    Task UpdateProductAsync(Product product);

    Task DeleteProductAsync(Guid id);

}