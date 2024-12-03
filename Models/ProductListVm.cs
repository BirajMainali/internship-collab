using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductApp.Models;

public class ProductListVm
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public decimal Price { get; set; }
    public long CategoryId { get; set; }

    public string Category { get; set; }
    public List<SelectListItem> Categories  { get; set; }

}