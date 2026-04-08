using Entities;
using Services.Interfaces;


namespace Services;

public class ProductService(IProductRepository repo) : IProductService
{
    public async Task<IEnumerable<Product>> GetStartPageProductsAsync()
    {
        return await repo.GetStartPageProductsAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsXCategory(Guid parentCategoryId)
    {
        var products = await repo.GetProductByParentCategoryAsync(parentCategoryId);
    }
}
