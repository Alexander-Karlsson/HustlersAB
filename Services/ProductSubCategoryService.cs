using Entities;
using Services.Interfaces.Categories;

namespace Services;

public class ProductSubCategoryService(IProductSubCategoryRepository repo) : IProductSubCategoryService
{
    public async Task<IEnumerable<ProductSubCategory>> GetAllAsync()
    {
        return await repo.GetAllAsync();
    }

    public async Task<ProductSubCategory?> GetByIdAsync(Guid id)
    {
        return await repo.GetByIdAsync(id);
    }

    public async Task<ProductSubCategory> CreateAsync(ProductSubCategory productSubCategory)
    {
        return await repo.CreateAsync(productSubCategory);
    }

    public async Task UpdateAsync(ProductSubCategory productSubCategory)
    {
        await repo.UpdateAsync(productSubCategory);
    }

    public async Task DeleteAsync(Guid id)
    {
        await repo.DeleteAsync(id);
    }
}