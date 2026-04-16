using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces.Categories;

namespace EF_MSSQL.Repositories;

public class ProductCategoryRepository(StoreDbContext db) : IProductCategoryRepository
{
    public async Task<IEnumerable<ProductCategory>> GetAllAsync()
        => await db.ProductCategories
        .AsNoTracking()
        .ToListAsync();
}
