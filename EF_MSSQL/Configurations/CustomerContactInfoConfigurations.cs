using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_MSSQL.Configurations;

public class CustomerContactInfoConfigurations : IEntityTypeConfiguration<CustomerContactInfo>
{
    public void Configure(EntityTypeBuilder<CustomerContactInfo> builder)
    {
        builder
            .HasOne(c => c.Customer)
            .WithOne(c => c.CustomerContactInfo)
            .HasForeignKey<CustomerContactInfo>(c => c.CustomerId);

        builder
            .Property(ci => ci.Phone)
            .HasMaxLength(20)
            .IsRequired();

        builder
            .Property(ci => ci.Email)
            .HasMaxLength(100)
            .IsRequired();


        builder
            .Property(ci => ci.Address)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(ci => ci.PostalNumber)
            .HasMaxLength(10)
            .IsRequired();

        builder.HasIndex(ci => ci.Email).IsUnique();
    }
}