using ProductApp.Entities;

namespace ProductApp.Dto;

public class ImageUploadDto
{
    public long Id{get;set;}
    public string ImageUrl { get; set; }
    public long FoodId{get;set;}

}