using Entities;
using Services.Interfaces;

namespace Services;

public class ProductService(IProductRepository repo) : IProductService
{
    private readonly IProductRepository _repo = repo;
    public async Task AddProductAsync(Product product)
    {
        if (product == null) throw new ArgumentNullException("Product can not be null");
        await _repo.AddAsync(product);
    }

    public async Task DeleteProductAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id can not be empty");
        await _repo.DeleteAsync(id);
    }

    public async Task<IEnumerable<Product>> GetProductByCategoryAsync(int categoryId)
    {
        return await _repo.GetByCategoryAsync(categoryId);
    }

    public async Task<Product?> GetProductByIdAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id can not be empty");
        return await _repo.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<IEnumerable<Product>> SearchProductAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm)) throw new ArgumentNullException("Search term can not be null");
        return await _repo.SearchAsync(searchTerm);
    }

    public async Task UpdateProductAsync(Product product)
    {
        if (product == null) throw new ArgumentNullException("Product can not be null");
        await _repo.UpdateAsync(product);
    }
}