
using ProductApp.Dto;
using ProductApp.Entities;

namespace ProductApp.Services.Interfaces;

public interface IImageUploadService
{
    Task <ImageUpload>Upload(ImageUploadDto dto);
}