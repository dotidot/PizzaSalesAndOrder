using System.ComponentModel.DataAnnotations;

namespace PizzaSalesAndOrder.Dto.Pizzas;

public class BulkImportPizzaDto
{
    [Required]
    public IFormFile File { get; set; }
}
