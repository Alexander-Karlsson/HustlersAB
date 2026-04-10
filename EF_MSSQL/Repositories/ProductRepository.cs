using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces.Products;

namespace EF_MSSQL.Repositories;

public class ProductRepository(StoreDbContext db) : IProductRepository
{
    private IQueryable<Product> GetProductsWithIncludes()
        => db.Products
            .Include(p => p.SubCategory)
            .ThenInclude(sc => sc.ParentCategory);

    public async Task<IEnumerable<Product>> GetProductByParentCategoryAsync(string query)
        => await GetProductsWithIncludes()
            .Where(p => p.SubCategory != null && p.SubCategory.ParentCategory.Name == query).ToListAsync();

    public async Task<IEnumerable<Product>> GetAllAsync()
        => await GetProductsWithIncludes()
            .AsNoTracking()
            .ToListAsync();

    public async Task<Product?> GetByIdAsync(Guid id)
        => await GetProductsWithIncludes()
            .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<IEnumerable<Product>> GetBySearchAsync(string query)
        => await GetProductsWithIncludes()
            .Where(p => p.Name.Contains(query))
            .ToListAsync();
            
    public async Task<IEnumerable<Product>> GetStartPageProductsAsync() 
        => await GetProductsWithIncludes()
        .Take(3)
        .ToListAsync();

    public async Task<Product> CreateAsync(Product product)
    {
        await db.Products.AddAsync(product);
        await db.SaveChangesAsync();
        
        return product;
    }
    
    public async Task UpdateAsync(Product product)
    {
        db.Products.Update(product);
        await db.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var product = await db.Products.FindAsync(id);
        if (product is null) return;
        
        db.Products.Remove(product);
        await db.SaveChangesAsync();
    }
}