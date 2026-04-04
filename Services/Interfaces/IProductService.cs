using Entities;

namespace Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductsAsync();

    Task<Product?> GetProductByIdAsync(Guid id);

    Task<IEnumerable<Product>> GetProductByCategoryAsync(Guid categoryId);

    Task<IEnumerable<Product>> SearchProductAsync(string search);

    Task AddProductAsync(Product product);

    Task UpdateProductAsync(Product product);

    Task DeleteProductAsync(Guid id);

}