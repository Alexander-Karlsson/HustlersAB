using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces.Categories;

namespace EF_MSSQL.Repositories;

public class ProductSubCategoryRepository(StoreDbContext db) : IProductSubCategoryRepository
{
    public async Task<IEnumerable<ProductSubCategory>> GetAllAsync()
    {
        return await GetProductSubCategoriesWithIncludes()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ProductSubCategory?> GetByIdAsync(Guid id)
    {
        return await GetProductSubCategoriesWithIncludes()
            .FirstOrDefaultAsync(sc => sc.Id == id);
    }

    public async Task<ProductSubCategory> CreateAsync(ProductSubCategory productSubCategory)
    {
        await db.ProductSubCategories.AddAsync(productSubCategory);
        await db.SaveChangesAsync();

        return productSubCategory;
    }

    public async Task UpdateAsync(ProductSubCategory productSubCategory)
    {
        db.ProductSubCategories.Update(productSubCategory);
        await db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var subCat = await db.ProductSubCategories.FindAsync(id);
        if (subCat is null) return;

        db.ProductSubCategories.Remove(subCat);
        await db.SaveChangesAsync();
    }

    private IQueryable<ProductSubCategory> GetProductSubCategoriesWithIncludes()
    {
        return db.ProductSubCategories
            .Include(sc => sc.ParentCategory);
    }
}