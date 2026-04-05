using Entities;
using Services.Interfaces;

namespace Services;

public class ProductService(IProductRepository repo) : IProductService
{

    public async Task AddProductAsync(Product product)
    {
        if (product == null) throw new ArgumentNullException("Product can not be null");
        await repo.AddAsync(product);
    }

    public async Task DeleteProductAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id can not be empty");
        await repo.DeleteAsync(id);
    }

    public async Task<IEnumerable<Product>> GetProductByCategoryAsync(Guid categoryId)
    {

        if (categoryId == Guid.Empty) throw new ArgumentException("CategoryId can not be empty");
        return await repo.GetByCategoryAsync(categoryId);
    }

    public async Task<Product?> GetProductByIdAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id can not be empty");
        return await repo.GetByIdAsync(id);
    }

    public async Task<bool> IsProductInStockAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id can not be empty");
        return await repo.IsInStockAsync(id);
    }

    public async Task<IEnumerable<Product>> GetProductsInStockAsync()
    {
        return await repo.GetInStockAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await repo.GetAllAsync();
    }

    public async Task<IEnumerable<Product>> SearchProductAsync(string search)
    {
        if (string.IsNullOrWhiteSpace(search)) throw new ArgumentNullException("Search term can not be null");
        return await repo.SearchAsync(search);
    }

    public async Task UpdateProductAsync(Product product)
    {
        if (product == null) throw new ArgumentNullException("Product can not be null");
        await repo.UpdateAsync(product);
    }
}