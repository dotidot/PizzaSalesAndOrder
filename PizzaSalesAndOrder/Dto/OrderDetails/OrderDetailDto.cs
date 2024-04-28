namespace PizzaSalesAndOrder.Dto.OrderDetails
{
    public class OrderDetailDto
    {
        public string OrderDetailId { get; set; }
        public string OrderId { get; set; }
        public string PizzaId { get; set; }
        public int Quantity { get; set; }
    }
}
