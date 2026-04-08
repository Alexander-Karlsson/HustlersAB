using Entities;

namespace Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetStartPageProductsAsync();
}