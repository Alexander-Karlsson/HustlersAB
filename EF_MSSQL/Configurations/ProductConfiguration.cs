using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_MSSQL.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(256);

        builder
            .Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(256);

        builder
            .Property(p => p.Price)
            .HasPrecision(18, 2);

        builder
            .ToTable(t => t.HasCheckConstraint("CK_Product_QtyInStock", "[QtyInStock] >= 0"));

        builder
            .HasOne(p => p.SubCategory)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.SubCategoryId)
            .IsRequired();

        builder
            .HasOne(p => p.Offer)
            .WithOne(o => o.Product)
            .HasForeignKey<Offer>(o => o.ProductId);
    }
}