using EF_MSSQL.Seeders;
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
    public DbSet<ProductOrder> ProductOrders { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        DataSeeder.Seed(modelBuilder);
    }
}