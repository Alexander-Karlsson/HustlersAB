using Entities;
using Services.Interfaces;

namespace Services;

public class ProductService(IProductRepository repo) : IProductService
{
    public async Task<List<Product>> GetProductsAsync()
    {
        var products = await repo.GetAllAsync();

        return products.Take(3).ToList();
    }

    public async Task<IEnumerable<Product>> GetByParentCategoryAsync(Guid parentCategoryId)
    {
        var all = await repo.GetAllAsync();

        return all.Where(p => p.SubCategory != null && p.SubCategory.ParentCategoryId == parentCategoryId);
    }
}
