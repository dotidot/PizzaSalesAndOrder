using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaSalesAndOrder.Domains.Entities;

namespace PizzaSalesAndOrder.EntityFrameworkCore.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(b => b.OrderId);
        builder.Property(b => b.OrderId)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(b => b.Date)
            .IsRequired();
    }
}
