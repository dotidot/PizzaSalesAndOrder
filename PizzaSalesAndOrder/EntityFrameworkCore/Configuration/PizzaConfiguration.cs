using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaSalesAndOrder.Domains.Entities;
using PizzaSalesAndOrder.Domains.Enums;

namespace PizzaSalesAndOrder.EntityFrameworkCore.Configuration;

public class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
{
    public void Configure(EntityTypeBuilder<Pizza> builder)
    {
        builder.HasKey(b => b.PizzaId);
        builder.Property(b => b.PizzaId)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(b => b.Price)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(b => b.Size)
            .IsRequired();

        builder.Property(b => b.PizzaTypeId)
            .IsRequired();
    }
}
