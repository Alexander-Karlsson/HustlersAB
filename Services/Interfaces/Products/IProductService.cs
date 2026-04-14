using Entities;

namespace Services.Interfaces.Products;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task<IEnumerable<Product>> GetBySearchAsync(string query);
    Task<IEnumerable<Product>> GetStartPageProductsAsync();
    Task SetStartPageProductsAsync(List<Guid> productIds);
    Task<IEnumerable<Product>> GetProductByParentCategoryAsync(string query);
    Task<Product> CreateAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Product>> GetAllSortedByNameAsync();
    Task<IEnumerable<Product>> GetAllSortedByPriceAsync();
}