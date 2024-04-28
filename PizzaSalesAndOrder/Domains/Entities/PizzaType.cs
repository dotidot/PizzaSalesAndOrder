namespace PizzaSalesAndOrder.Domains.Entities;

public class PizzaType
{
    public string PizzaTypeId { get; private set; }
    public string Name { get; private set; }
    public string Category { get; private set; }
    public string Ingredients { get; private set; }

    private PizzaType()
    {
    }

    /// <summary>
    /// Create a new Pizza Type
    /// </summary>
    /// <param name="pizzaTypeId"></param>
    /// <param name="name"></param>
    /// <param name="category"></param>
    /// <param name="ingredients"></param>
    public PizzaType(
        string pizzaTypeId,
        string name,
        string category,
        string ingredients)
    {
        PizzaTypeId = pizzaTypeId;
        Name = name;
        Category = category;
        Ingredients = ingredients;
    }
}
