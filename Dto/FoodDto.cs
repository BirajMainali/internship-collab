using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductApp.Dto;

public class FoodDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string  Description { get; set; }
    public long CategoryId { get; set; }
    public List<SelectListItem> Categories  = new List<SelectListItem>();
    public SelectList GetCategoryOptions ()=> new SelectList(Categories, nameof(SelectListItem.Value), nameof(SelectListItem.Text), CategoryId);
}