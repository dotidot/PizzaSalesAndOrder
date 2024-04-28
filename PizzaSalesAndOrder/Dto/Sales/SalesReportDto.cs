namespace PizzaSalesAndOrder.Dto.Sales;

public class SalesReportDto
{
    public string PizzaId { get; set; }
    public string Pizza { get; set; }
    public string Category { get; set; }
    public string Size { get; set; }
    public decimal TotalSales { get; set; }
    public int TotalItemSold { get; set; }
}
