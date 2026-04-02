using Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_MSSQL;

public class StoreDbContext(DbContextOptions<StoreDbContext> options) : DbContext(options)
{

    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Shipping> Shippings { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<CustomerContactInfo> CustomerContactInfo { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductSubCategory> ProductSubCategories { get; set; }
    
    
    

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);
    //    // modelBuilder.Entity<Product>().HasData(
    //    //     new Product { Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), Name = "iPhone", SubCategoryId = 1, SubCategory = },
    //    //     new Product { Id = Guid.Parse("a1b2c4d6-e5f9-7891-abcd-ef1234567890"), Name = "iPad" },
    //    //     new Product { Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234565490"), Name = "Mac" }
    //    // );

    //    // modelBuilder.Entity<ProductCategory>().HasData(
    //    //     new ProductCategory { Id = Guid.Parse("b1b3r3d4-e5f6-7890-acbd-ef1234565490"), Name = "Apple" }
    //    // );
    //}

}