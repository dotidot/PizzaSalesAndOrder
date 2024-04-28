using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PizzaSalesAndOrder.Domains.Entities;
using PizzaSalesAndOrder.Dto.OrderDetails;
using PizzaSalesAndOrder.Dto.Orders;
using PizzaSalesAndOrder.Dto.Pizzas;
using PizzaSalesAndOrder.EntityFrameworkCore;
using PizzaSalesAndOrder.Interfaces;
using PizzaSalesAndOrder.Services;

namespace PizzaSalesAndOrder.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class OrderDetailController : ControllerBase
{

    private readonly IBulkImportService _bulkImportService;
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public OrderDetailController(
        IBulkImportService bulkImportService,
        AppDbContext appDbContext,
        IMapper mapper)
    {
        _bulkImportService = bulkImportService;
        _appDbContext = appDbContext;
        _mapper = mapper;
    }


    [HttpPost]
    public async Task<IActionResult> BulkImportOrderDetails(BulkImportOrdersDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        using (var stream = request.File.OpenReadStream())
        {
            await _bulkImportService.ProcessBulkImportOrderDetails(stream!);
        }

        return Ok();
    }

    [HttpGet]
    public async Task<List<OrderDetailDto>> GetListAsync(int page, int pageSize)
    {
        var orderDetails = await _appDbContext.OrderDetails
            .OrderBy(x => x.OrderDetailId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return _mapper.Map<List<OrderDetail>, List<OrderDetailDto>>(orderDetails);
    }
}
