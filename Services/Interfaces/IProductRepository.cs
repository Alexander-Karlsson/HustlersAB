using Entities;

namespace Services.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(Guid id);

    Task<IEnumerable<Product>> GetByCategoryAsync(Guid categoryId);

    Task<IEnumerable<Product>> SearchAsync(string search);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Guid id);

}