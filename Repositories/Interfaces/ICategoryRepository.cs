using Microsoft.AspNetCore.Mvc.Rendering;
using ProductApp.Dto;
using ProductApp.Entities;

namespace ProductApp.Repositories.Interfaces;

public interface ICategoryRepository
{
     List<CategoryDto> GetAll();
     CategoryDto GetById(long id);
     List<SelectListItem> GetCategories();
}