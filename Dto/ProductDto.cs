using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductApp.Dto;

public class ProductDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public long CategoryId { get; set; }
    public IEnumerable<SelectListItem> Categories { get; set; }
}