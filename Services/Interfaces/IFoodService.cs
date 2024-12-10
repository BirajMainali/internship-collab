using ProductApp.Dto;
using ProductApp.Entities;

namespace ProductApp.Services.Interfaces;

public interface IFoodService
{
     Task<Food> Create(FoodDto dto);
    Task<Food> Edit(FoodDto dto);
    void Delete(long id);
}