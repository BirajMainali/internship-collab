using ProductApp.Dto;

namespace ProductApp.Services.Interfaces;

public interface ICategoryService
{
    public Task Create(CategoryDto dto);
    public void Edit (CategoryDto dto);
    public void Delete (long id);
    
}