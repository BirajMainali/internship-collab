using ProductApp.Dto;

namespace ProductApp.Repositories.Interfaces;

public interface ICategoryRepository
{
     List<CategoryDto> GetAll();
     CategoryDto GetById(long id);
}