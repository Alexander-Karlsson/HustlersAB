using Entities;
using Services.Interfaces.Products;

namespace Services;

public class ProductService(IProductRepository repo) : IProductService
{
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await repo.GetAllAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await repo.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Product>> GetBySearchAsync(string query)
    {
        return await repo.GetBySearchAsync(query);
    }

    public async Task<IEnumerable<Product>> GetStartPageProductsAsync()
    {
        return await repo.GetStartPageProductsAsync();
    }

    public async Task<IEnumerable<Product>> GetProductByParentCategoryAsync(string query)
    {
        return await repo.GetProductByParentCategoryAsync(query);
    }

    public async Task<Product> CreateAsync(Product product)
    {
        return await repo.CreateAsync(product);
    }

    public async Task UpdateAsync(Product product)
    {
        await repo.UpdateAsync(product);
    }

    public async Task DeleteAsync(Guid id)
    {
        await repo.DeleteAsync(id);
    }
}