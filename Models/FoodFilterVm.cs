using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductApp.Models;

public class FoodFilterVm
{
  public List<FoodListVm>Foods { get; set; }  
  public SelectList Categories { get; set; }
  public long? SelectedCategoryId { get; set; }
}