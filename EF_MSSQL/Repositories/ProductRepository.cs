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

    public async Task<IEnumerable<Product>> GetAllSortedByNameAsync()
        => await GetProductsWithIncludes()
        .AsNoTracking()
        .OrderBy(p => p.Name)
        .ToListAsync();

    public async Task<IEnumerable<Product>> GetAllSortedByPriceAsync()
        => await GetProductsWithIncludes()
        .AsNoTracking()
        .OrderBy(p => p.Price)
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
        .Where(p => p.IsStartPage)
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
    public async Task SetStartPageProductsAsync(List<Guid> selectedIds)
    {
        var allProducts = await db.Products.ToListAsync();

        foreach (var product in allProducts)
        {
            if (selectedIds.Contains(product.Id))
            {
                product.IsStartPage = true;
            }
            else
            {
                product.IsStartPage = false;
            }
        }
        await db.SaveChangesAsync();
    }
}