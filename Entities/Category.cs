using System.ComponentModel.DataAnnotations;

namespace ProductApp.Entities;

public class Category
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Food> Foods { get; set; }
}