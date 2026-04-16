using Entities;
using Services.Interfaces.Categories;

namespace Services;

public class ProductCategoryService(IProductCategoryRepository repo) : IProductCategoryService
{
    public async Task<IEnumerable<ProductCategory>> GetAllAsync()
        => await repo.GetAllAsync();
}
