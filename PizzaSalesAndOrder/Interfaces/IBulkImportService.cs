namespace PizzaSalesAndOrder.Interfaces;

public interface IBulkImportService
{
    Task ProcessBulkImportOrderDetails(Stream stream);
    Task ProcessBulkImportOrders(Stream stream);
    Task ProcessBulkImportPizzas(Stream stream);
    Task ProcessBulkImportPizzaTypes(Stream stream);
}
