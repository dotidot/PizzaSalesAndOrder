using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaSalesAndOrder.Domains.Entities;
using PizzaSalesAndOrder.Dto.Orders;
using PizzaSalesAndOrder.Dto.PizzaTypes;
using PizzaSalesAndOrder.EntityFrameworkCore;
using PizzaSalesAndOrder.Interfaces;

namespace PizzaSalesAndOrder.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class OrderController : ControllerBase
{
    private readonly IBulkImportService _bulkImportService;
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public OrderController(
        IBulkImportService bulkImportService,
        AppDbContext appDbContext,
        IMapper mapper)
    {
        _bulkImportService = bulkImportService;
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> BulkImportOrders(BulkImportOrdersDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        using (var stream = request.File.OpenReadStream())
        {
            await _bulkImportService.ProcessBulkImportOrders(stream!);
        }

        return Ok();
    }


    [HttpGet]
    public async Task<List<OrderDto>> GetListAsync(int page, int pageSize)
    {
        var orders = await _appDbContext.Orders
            .OrderBy(x => x.OrderId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return _mapper.Map<List<Order>, List<OrderDto>>(orders);
    }
}
