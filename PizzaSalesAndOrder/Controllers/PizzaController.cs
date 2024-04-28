using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaSalesAndOrder.Domains.Entities;
using PizzaSalesAndOrder.Dto.Pizzas;
using PizzaSalesAndOrder.EntityFrameworkCore;
using PizzaSalesAndOrder.Interfaces;

namespace PizzaSalesAndOrder.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PizzaController : ControllerBase
{

    private readonly IBulkImportService _bulkImportService;
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public PizzaController(
        IBulkImportService bulkImportService,
        IMapper mapper,
        AppDbContext appDbContext)
    {
        _bulkImportService = bulkImportService;
        _mapper = mapper;
        _appDbContext = appDbContext;
    }

    [HttpPost]
    public async Task<IActionResult> BulkImportPizzas(BulkImportPizzaDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        using (var stream = request.File.OpenReadStream())
        {
            await _bulkImportService.ProcessBulkImportPizzas(stream!);
        }

        return Ok();
    }

    [HttpGet]
    public async Task<List<PizzaDto>> GetListAsync(int page, int pageSize)
    {
        var pizzas = await _appDbContext.Pizzas
            .OrderBy(x => x.PizzaId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return _mapper.Map<List<Pizza>, List<PizzaDto>>(pizzas);
    }
}
