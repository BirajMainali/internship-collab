using ProductApp.Data;
using ProductApp.Dto;
using ProductApp.Entities;
using ProductApp.Services.Interfaces;

namespace ProductApp.Services;

public class FoodService: IFoodService
{
    public ApplicationDbContext _context;
    

    public FoodService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task Create(FoodDto dto)
    {
        var food = new Food();
        food.Name = dto.Name;
        food.Price = dto.Price;
        food.Description = dto.Description;
        food.CategoryId = dto.CategoryId;
        _context.Foods.Add(food);
        await _context.SaveChangesAsync();
    }

    public void Edit(FoodDto dto)
    {
        var food = _context.Foods.FirstOrDefault(f => f.Id == dto.Id);
        food.Name = dto.Name;
        food.Price = dto.Price;
        food.Description = dto.Description;
        food.CategoryId = dto.CategoryId;
        _context.Foods.Update(food);
        _context.SaveChanges();
        
    }

    public void Delete(long id)
    {
        var food = _context.Foods.FirstOrDefault(f => f.Id == id);
        _context.Foods.Remove(food); 
        _context.SaveChanges();
        
    }
}