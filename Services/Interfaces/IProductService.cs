using Entities;

namespace Services.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync();
}