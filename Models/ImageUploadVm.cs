using ProductApp.Entities;

namespace ProductApp.Models;

public class ImageUploadVm
{
    public string ImageUrl { get; set; }
    public long FoodId{get;set;}
    public Food Food { get; set; }

}