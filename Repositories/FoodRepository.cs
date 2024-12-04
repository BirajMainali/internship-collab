using Microsoft.AspNetCore.Mvc.Rendering;
using ProductApp.Data;
using ProductApp.Dto;
using ProductApp.Entities;
using ProductApp.Repositories.Interfaces;

namespace ProductApp.Repositories;

public class FoodRepository:IFoodRepository
{
    public ApplicationDbContext _context;

    public FoodRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Food> GetAll()
    {
        return _context.Foods.ToList();





    }

   
    public IQueryable<Food> GetQueryable()
    {
        return _context.Foods;
    }
    public FoodDto GetById(long id)
    {
        var food = _context.Foods.Find(id);
        var dto = new FoodDto()
        {
            Id = food.Id,
            Name = food.Name,
            Description = food.Description,
            CategoryId =food.CategoryId,
            Price = food.Price,
        };
        return dto;
    }


    
}