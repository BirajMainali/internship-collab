using ProductApp.Dto;
using ProductApp.Entities;

namespace ProductApp.Services.Interfaces;

public interface ICategoryService
{
    Task<Category > Create(CategoryDto dto);
    Task<Category > Edit(CategoryDto dto);
     void Delete(long id);
}
