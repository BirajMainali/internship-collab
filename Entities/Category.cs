using System.ComponentModel.DataAnnotations;

namespace ProductApp.Entities;

public class Category
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Product> Products { get; set; }
    public ICollection<Food> Foods { get; set; }
}