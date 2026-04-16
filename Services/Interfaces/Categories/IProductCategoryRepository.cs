using Entities;

namespace Services.Interfaces.Categories;

public interface IProductCategoryRepository
{
    Task<IEnumerable<ProductCategory>> GetAllAsync();
}
