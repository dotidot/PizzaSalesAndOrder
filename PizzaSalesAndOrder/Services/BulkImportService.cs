using EFCore.BulkExtensions;
using PizzaSalesAndOrder.Domains.Entities;
using PizzaSalesAndOrder.EntityFrameworkCore;
using PizzaSalesAndOrder.Interfaces;

namespace PizzaSalesAndOrder.Services;

public class BulkImportService : IBulkImportService
{
    private readonly AppDbContext _appDbContext;
    public BulkImportService(
        AppDbContext appDbContext,
        IHostEnvironment hostEnvironment)
    {
        _appDbContext = appDbContext;
    }

    public async Task ProcessBulkImportOrderDetails(Stream stream)
    {
        try
        {

            using (var streamReader = new StreamReader(stream))
            {
                var content = streamReader.ReadToEnd();
                var rows = content.Split("\r\n").Skip(1).Where(x => !string.IsNullOrWhiteSpace(x));

                var orderDetails = new List<OrderDetail>();
                foreach (var row in rows)
                {
                    var col = row.Split(",");
                    orderDetails.Add(new OrderDetail(
                            orderDetailId: col[0],
                            orderId: long.Parse(col[1]),
                            pizzaId: col[2],
                            quantity: int.Parse(col[3])
                    ));
                }

                await _appDbContext.BulkInsertAsync(orderDetails);
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task ProcessBulkImportOrders(Stream stream)
    {
        try
        {

            using (var streamReader = new StreamReader(stream))
            {
                var content = streamReader.ReadToEnd();
                var rows = content.Split("\r\n").Skip(1).Where(x => !string.IsNullOrWhiteSpace(x));

                var orders = new List<Order>();
                foreach (var row in rows)
                {
                    var col = row.Split(",");
                    orders.Add(new Order(
                        orderId: long.Parse(col[0]),
                        date: DateTime.ParseExact(string.Join(" ", col[1], col[2]), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)
                    ));
                }

                await _appDbContext.BulkInsertAsync(orders);
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task ProcessBulkImportPizzas(Stream stream)
    {
        try
        {
            using (var streamReader = new StreamReader(stream))
            {
                var content = streamReader.ReadToEnd();
                var rows = content.Split("\r\n").Skip(1).Where(x => !string.IsNullOrWhiteSpace(x));

                var pizzas = new List<Pizza>();
                foreach (var row in rows)
                {
                    var col = row.Split(",");
                    pizzas.Add(new Pizza(
                            pizzaId: col[0],
                            pizzaTypeId: col[1],
                            size: col[2],
                            price: decimal.Parse(col[3])
                    ));
                }

                await _appDbContext.BulkInsertAsync(pizzas);
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task ProcessBulkImportPizzaTypes(Stream stream)
    {
        try
        {
            using (var streamReader = new StreamReader(stream))
            {
                var content = streamReader.ReadToEnd();
                var rows = content.Split("\r\n").Skip(1).Where(x => !string.IsNullOrWhiteSpace(x));

                var pizzaTypes = new List<PizzaType>();
                foreach (var row in rows)
                {
                    var col = row.Split(",");
                    pizzaTypes.Add(new PizzaType(
                        pizzaTypeId: col[0],
                        name: col[1],
                        category: col[2],
                        ingredients: col[3]
                    ));
                }

                await _appDbContext.BulkInsertAsync(pizzaTypes);
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}
