using System.ComponentModel.DataAnnotations;

namespace ProductApp.Entities;

public class Food
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string  Description { get; set; }
    public long CategoryId { get; set; }
    public  virtual Category Category{ get; set; }
    
}