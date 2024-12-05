using System.ComponentModel.DataAnnotations;

namespace ProductApp.Models;

public class CategoryVm
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
}