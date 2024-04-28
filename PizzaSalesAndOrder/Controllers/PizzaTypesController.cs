using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PizzaSalesAndOrder.Domains.Entities;
using PizzaSalesAndOrder.Dto.PizzaTypes;
using PizzaSalesAndOrder.EntityFrameworkCore;
using PizzaSalesAndOrder.Interfaces;
using PizzaSalesAndOrder.Services;

namespace PizzaSalesAndOrder.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PizzaTypesController : ControllerBase
{
    private readonly IBulkImportService _bulkImportService;
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public PizzaTypesController(
        IBulkImportService bulkImportService,
        AppDbContext appDbContext,
        IMapper mapper)
    {
        _bulkImportService = bulkImportService;
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> BulkImportPizzaTypes(BulkImportPizzaTypesDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        using (var stream = request.File.OpenReadStream())
        {
            await _bulkImportService.ProcessBulkImportPizzaTypes(stream!);
        }

        return Ok();
    }

    [HttpGet] 
    public async Task<List<PizzaTypeDto>> GetListAsync(int page, int pageSize)
    {
        var pizzaTypes = await _appDbContext.PizzaTypes
            .OrderBy(x => x.PizzaTypeId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return _mapper.Map<List<PizzaType>, List<PizzaTypeDto>>(pizzaTypes);
    }
}
