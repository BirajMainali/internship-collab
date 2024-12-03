using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging.EventLog;

namespace ProductApp.Models;

public class FoodListVm
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    public string  Description { get; set; }
    public long CategoryId { get; set; }
    public string  Category { get; set; }
}