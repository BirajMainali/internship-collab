using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductApp.Models;

public class ProductVm
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public long CategoryId { get; set; }
    
    public IEnumerable<SelectListItem> Categories { get; set; }
}