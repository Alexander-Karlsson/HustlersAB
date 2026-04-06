using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_MSSQL.Configurations;

public class OfferConfigurations : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder
            .Property(o => o.NewPrice)
            .HasColumnType("decimal(18,2)");

        builder
            .HasOne(o => o.Product)
            .WithOne(o => o.Offer)
            .HasForeignKey<Offer>(o => o.ProductId);
        
        builder
            .Property(o => o.StartDate)
            .IsRequired();
        
        builder
            .Property(o => o.EndDate)
            .IsRequired();
        
        builder
            .ToTable(t => t.HasCheckConstraint("CK_Offer_Dates", "EndDate > StartDate"));
    }
}