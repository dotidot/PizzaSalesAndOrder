using System.Drawing;

namespace PizzaSalesAndOrder.Domains.Entities;

public class Pizza
{
    public string PizzaId { get; private set; }
    public string PizzaTypeId { get; private set; }
    public string Size { get; private set; }
    public decimal Price { get; private set; }

    private Pizza()
    {
    }

    /// <summary>
    /// Create a new Pizza
    /// </summary>
    /// <param name="pizzaId"></param>
    /// <param name="pizzaTypeId"></param>
    /// <param name="size"></param>
    /// <param name="price"></param>
    public Pizza(
        string pizzaId,
        string pizzaTypeId,
        string size,
        decimal price)
    {
        PizzaId = pizzaId;
        PizzaTypeId = pizzaTypeId;
        Size = size;
        Price = price;
    }
}
