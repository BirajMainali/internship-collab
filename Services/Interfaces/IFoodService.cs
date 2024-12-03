using ProductApp.Dto;
using ProductApp.Entities;

namespace ProductApp.Services.Interfaces;

public interface IFoodService
{
    public Task<Food> Create(FoodDto dto);
    public void Edit(FoodDto dto);
    public void Delete(long id);
}