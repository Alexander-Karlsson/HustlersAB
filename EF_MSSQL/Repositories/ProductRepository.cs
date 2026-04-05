using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;


namespace EF_MSSQL.Repositories;

public class ProductRepository(StoreDbContext context) : IProductRepository
{
    private readonly StoreDbContext _context = context;

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetInStockAsync()
    {
        return await _context.Products
            .Include(p => p.SubCategory)
            .ThenInclude(s => s.ParentCategory)
            .Where(p => p.QtyInStock > 0)
            .ToListAsync();
    }
    public async Task<bool> IsInStockAsync(Guid id)
    {
        var product = await GetByIdAsync(id);
        if (product == null) return false;
        return product.QtyInStock > 0;
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await GetByIdAsync(id);
        if (product == null) return;
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products
            .Include(p => p.SubCategory)
            .ThenInclude(s => s.ParentCategory)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetByCategoryAsync(Guid categoryId)
    {
        return await _context.Products
            .Include(p => p.SubCategory)
            .ThenInclude(s => s.ParentCategory)
            .Where(p => p.SubCategoryId == categoryId)
            .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Products
         .Include(p => p.SubCategory)
         .ThenInclude(s => s.ParentCategory)
         .Include(p => p.Offer)
         .Include(p => p.ProductOrders)
         .ThenInclude(po => po.Order)
         .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> SearchAsync(string search)
    {
        return await _context.Products
            .Include(p => p.SubCategory)
            .ThenInclude(s => s.ParentCategory)
            .Where(p => p.Name.Contains(search) ||
            p.Description.Contains(search))
            .ToListAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }
}