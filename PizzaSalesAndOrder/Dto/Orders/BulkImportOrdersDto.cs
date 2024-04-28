using System.ComponentModel.DataAnnotations;

namespace PizzaSalesAndOrder.Dto.Orders;

public class BulkImportOrdersDto
{
    [Required] 
    public IFormFile File { get; set; }
}
