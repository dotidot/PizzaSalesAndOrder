using System.ComponentModel.DataAnnotations;

namespace PizzaSalesAndOrder.Dto.OrderDetails;

public class BulkImportOrderDetailsDto
{
    [Required]
    public IFormFile File { get; set; }
}
