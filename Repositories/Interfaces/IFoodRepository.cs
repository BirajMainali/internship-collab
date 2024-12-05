using ProductApp.Dto;
using ProductApp.Entities;

namespace ProductApp.Repositories.Interfaces;

public interface IFoodRepository
{
    List<Food> GetAll();
    FoodDto GetById(long id);
    IQueryable<Food> GetQueryable();


   
}