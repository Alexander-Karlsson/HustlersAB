using Entities;

namespace Services.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync();
    Task<IEnumerable<Product>> GetProductsXCategory(Guid parentCategoryId);
    Task<IEnumerable<Product>> GetStartPageProductsAsync();
}