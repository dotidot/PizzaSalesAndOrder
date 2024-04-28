using Microsoft.EntityFrameworkCore;
using PizzaSalesAndOrder.Domains.Entities;

namespace PizzaSalesAndOrder.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions option) : base(option)
    {
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<PizzaType> PizzaTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

}
