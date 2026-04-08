using Entities;

namespace Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductsXCategory(Guid parentCategoryId);
    Task<IEnumerable<Product>> GetStartPageProductsAsync();
}