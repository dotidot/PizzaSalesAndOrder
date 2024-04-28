using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaSalesAndOrder.Domains.Entities;

namespace PizzaSalesAndOrder.EntityFrameworkCore.Configuration;

public class PizzaTypeConfiguration : IEntityTypeConfiguration<PizzaType>
{
    public void Configure(EntityTypeBuilder<PizzaType> builder)
    {
        builder.HasKey(b => b.PizzaTypeId);
        builder.Property(b => b.PizzaTypeId)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(b => b.Name)
            .IsRequired();

        builder.Property(b => b.Category)
            .IsRequired();

        builder.Property(b => b.Ingredients)
            .IsRequired();

    }
}
