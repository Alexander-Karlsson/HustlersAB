using Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_MSSQL;

public class StoreDbContext(DbContextOptions<StoreDbContext> options) : DbContext(options)
{
    
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), Name = "iPhone" },
            new Product { Id = Guid.Parse("a1b2c4d6-e5f9-7891-abcd-ef1234567890"), Name = "iPad" },
            new Product { Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234565490"), Name = "Mac" }
        );

        modelBuilder.Entity<ProductCategory>().HasData(
            new ProductCategory { Id = Guid.Parse("b1b3r3d4-e5f6-7890-acbd-ef1234565490"), Name = "Apple" }
        );
    }
}