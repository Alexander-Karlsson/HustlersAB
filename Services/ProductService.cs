using Entities;
using Services.Interfaces;
using Services.Interfaces.Products;


namespace Services;

public class ProductService(IProductRepository repo) : IProductService
{
    public async Task<IEnumerable<Product>> GetAllAsync()
        => await repo.GetAllAsync();

    public async Task<IEnumerable<Product>> GetAllSortedByNameAsync()
        => await repo.GetAllSortedByPriceAsync();

    public async Task<IEnumerable<Product>> GetAllSortedByPriceAsync()
        => await repo.GetAllSortedByPriceAsync();

    public async Task<Product?> GetByIdAsync(Guid id)
        => await repo.GetByIdAsync(id);
    
    public async Task<IEnumerable<Product>> GetBySearchAsync(string query)
        => await repo.GetBySearchAsync(query);
    
    public async Task<IEnumerable<Product>> GetStartPageProductsAsync()
        => await repo.GetStartPageProductsAsync();
    
    public async Task<IEnumerable<Product>> GetProductByParentCategoryAsync(string query)
        => await repo.GetProductByParentCategoryAsync(query);
    
    public async Task<Product> CreateAsync(Product product)
        => await repo.CreateAsync(product);
    
    public async Task UpdateAsync(Product product)
        => await repo.UpdateAsync(product);
    
    public async Task DeleteAsync(Guid id)
        => await repo.DeleteAsync(id);
    
    
    
}