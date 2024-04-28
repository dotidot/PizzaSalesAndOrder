using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaSalesAndOrder.Domains.Entities;

namespace PizzaSalesAndOrder.EntityFrameworkCore.Configuration;

public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.HasKey(b => b.OrderDetailId);
        builder.Property(b => b.OrderDetailId)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(b => b.Quantity)
            .IsRequired();

        builder.Property(b => b.OrderDetailId)
            .IsRequired();

        builder.Property(b => b.OrderId)
            .IsRequired();

        builder.Property(b => b.PizzaId)
            .IsRequired();
    }
}
