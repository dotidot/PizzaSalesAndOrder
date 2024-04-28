using System.ComponentModel.DataAnnotations;

namespace PizzaSalesAndOrder.Dto.PizzaTypes;

public class BulkImportPizzaTypesDto
{
    [Required]
    public IFormFile File { get; set; }
}
