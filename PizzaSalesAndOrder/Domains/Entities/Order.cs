namespace PizzaSalesAndOrder.Domains.Entities;

public class Order
{
    public long OrderId { get; private set; }
    public DateTime Date { get; private set; }

    private Order()
    {
    }

    /// <summary>
    /// Create a new Order
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="date"></param>
    public Order(
        long orderId,
        DateTime date)
    {
        OrderId = orderId;
        Date = date;
    }
}
