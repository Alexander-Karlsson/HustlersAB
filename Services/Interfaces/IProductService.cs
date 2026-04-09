using Entities;

namespace Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductByParentCategoryAsync(string query);
    Task<IEnumerable<Product>> GetStartPageProductsAsync();
}