using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Dto;
using ProductApp.Models;
using ProductApp.Services.Interfaces;

namespace ProductApp.Controllers;

public class ImageController : Controller
{
    private readonly IImageUploadService _imageUploadService;

    public ImageController(IImageUploadService imageUploadService)
    {
        _imageUploadService = imageUploadService;
    }

    public IActionResult Add(long id)
    {
        var vm = new ImageUploadVm();
        vm.FoodId = id;
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Add(long foodId, IFormFile image)
    {
        if (image == null && image.Length < 0) return View();
        try
        {
           
           
            var filepath = Path.Combine("wwwroot/images", Path.GetFileName(image.FileName));
            using (var stream = new FileStream(filepath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            var dto = new ImageUploadDto()
            {
                FoodId = foodId,
                ImageUrl = $"/images/{image.FileName}",
            };
            await _imageUploadService.Upload(dto);
            TempData["success"] = "Image Uploaded";
            return RedirectToAction("Index", "Food");
        }
        catch (Exception e)
        {
            TempData["error"] = e.Message;
            return RedirectToAction("Index", "Food");
        }
    }
}