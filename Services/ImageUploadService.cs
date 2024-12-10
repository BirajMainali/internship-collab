using ProductApp.Data;
using ProductApp.Dto;
using ProductApp.Entities;
using ProductApp.Services.Interfaces;

namespace ProductApp.Services;

public class ImageUploadService: IImageUploadService
{
    private readonly ApplicationDbContext _context;

    public ImageUploadService(ApplicationDbContext context)
    {
        _context = context;
    }
    public  async Task <ImageUpload> Upload(ImageUploadDto dto)
    {
        var imageupload = new ImageUpload()
        {
            FoodId = dto.FoodId,
            ImageUrl = dto.ImageUrl,
        };
       await _context.ImageUploads.AddAsync(imageupload);
       await _context.SaveChangesAsync();
       return imageupload;
        
    }
}