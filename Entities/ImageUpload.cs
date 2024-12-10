namespace ProductApp.Entities;

public class ImageUpload
{
    public long Id{get;set;}
    public string ImageUrl { get; set; }
    public long FoodId{get;set;} //Foreign key
    public Food Food { get; set; }

}