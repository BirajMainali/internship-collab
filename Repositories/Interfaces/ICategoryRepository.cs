using Microsoft.AspNetCore.Mvc.Rendering;
using ProductApp.Dto;
using ProductApp.Entities;

namespace ProductApp.Repositories.Interfaces;

public interface ICategoryRepository
{
    List<CategoryDto> GetAll();
    List<SelectListItem> GetCategories();
    CategoryDto GetById(long id);
}


