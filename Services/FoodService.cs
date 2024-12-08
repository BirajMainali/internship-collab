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
    
    public async Task<Food> Create(FoodDto dto)
    {
        var food = new Food();
        food.Name = dto.Name;
        food.Price = dto.Price;
        food.Description = dto.Description;
        food.CategoryId = dto.CategoryId;
       await _context.Foods.AddAsync(food);
        await _context.SaveChangesAsync();

        return food;
    }

    public async Task<Food> Edit(FoodDto dto)
    {
        var food = _context.Foods.Find(  dto.Id);
        food.Name = dto.Name;
        food.Price = dto.Price;
        food.Description = dto.Description;
        food.CategoryId = dto.CategoryId;
        
        await _context.SaveChangesAsync();
        return food;
        
    }

    public void Delete(long id)
    {
        var food = _context.Foods.FirstOrDefault(f => f.Id == id);
        _context.Foods.Remove(food); 
        _context.SaveChanges();
        
    }
}