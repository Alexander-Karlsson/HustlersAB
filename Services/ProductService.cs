using Services.Interfaces;

namespace Services;

public class ProductService(IProductRepository repo) : IProductService
{
    
}