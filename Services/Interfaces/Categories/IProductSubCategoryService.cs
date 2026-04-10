using Entities;

namespace Services.Interfaces.Categories;

public interface IProductSubCategoryService
{
    Task<IEnumerable<ProductSubCategory>> GetAllAsync();
    Task<ProductSubCategory?> GetByIdAsync(Guid id);
    Task<ProductSubCategory> CreateAsync(ProductSubCategory productSubCategory);
    Task UpdateAsync(ProductSubCategory productSubCategory);
    Task DeleteAsync(Guid id);
}