using Entities;

namespace Services.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync();
    Task<IEnumerable<Product>> GetByParentCategoryAsync(Guid parentCategoryId);
}