using ProductApp.Dto;
using ProductApp.Entities;

namespace ProductApp.Repositories.Interfaces;

public interface IFoodRepository
{
    List<FoodDto> GetAll();
    FoodDto GetById(long id);

}