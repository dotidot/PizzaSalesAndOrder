using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaSalesAndOrder.Dto.Sales;
using PizzaSalesAndOrder.EntityFrameworkCore;

namespace PizzaSalesAndOrder.Controllers;


[ApiController]
[Route("[controller]/[action]")]
public class SalesController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public SalesController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetReportAsync()
    {
        var sales = await (from p in _appDbContext.Pizzas
                    join pt in _appDbContext.PizzaTypes on p.PizzaTypeId equals pt.PizzaTypeId
                    join od in _appDbContext.OrderDetails on p.PizzaId equals od.PizzaId into ods
                    let totalItemsSold = ods.Sum(g => g.Quantity)
                    let totalSales = totalItemsSold * p.Price
                    select new SalesReportDto
                    {
                        PizzaId = p.PizzaId,
                        Pizza = pt.Name,
                        Category = pt.Category,
                        Size = p.Size,
                        TotalItemSold = totalItemsSold,
                        TotalSales = totalSales
                    }).ToListAsync();


        return Ok(sales);
    }
}
