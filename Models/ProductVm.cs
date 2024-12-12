using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductApp.Models;

public class ProductVm
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative.")]
    
    public decimal Price { get; set; }
    [Required]
    public long? CategoryId { get; set; }

    public List<SelectListItem> Categories  = new List<SelectListItem>();
    public SelectList GetCategoryOptions ()=> new SelectList(Categories, nameof(SelectListItem.Value), nameof(SelectListItem.Text), CategoryId);
}