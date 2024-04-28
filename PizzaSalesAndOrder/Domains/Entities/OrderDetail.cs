namespace PizzaSalesAndOrder.Domains.Entities;

public class OrderDetail
{
    public string OrderDetailId { get; private set; }
    public long OrderId { get; private set; }
    public string PizzaId { get; private set; }
    public int Quantity { get; private set; } = 1;

    private OrderDetail()
    {    
    }

    /// <summary>
    /// Create a new Order Detail
    /// </summary>
    /// <param name="orderDetailId"></param>
    /// <param name="orderId"></param>
    /// <param name="pizzaId"></param>
    /// <param name="quantity"></param>
    public OrderDetail(
        string orderDetailId,
        long orderId,
        string pizzaId,
        int quantity)
    {
        OrderDetailId = orderDetailId;
        OrderId = orderId;
        PizzaId = pizzaId;
        Quantity = quantity;
    }
}
