using ProductApp.Dto;

namespace ProductApp.Services.Interfaces;

public interface ICategoryService
{
    public Task Create(CategoryDto dto);
    public void Edit (CategoryDto sto);
    public void Delete (long id);
}