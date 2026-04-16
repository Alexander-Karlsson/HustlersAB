using Entities;

namespace Services.Interfaces.Categories;

public interface IProductCategoryService
{
    Task<IEnumerable<ProductCategory>> GetAllAsync();
}
