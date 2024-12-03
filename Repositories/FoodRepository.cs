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

    public FoodDto GetById(long id)
    {
        var dto = _context.Foods.Where(x => x.Id == id).Select(x => new FoodDto
        {
            Id = x.Id,
            Name = x.Name,
            Price = x.Price,
            Description = x.Description,
            CategoryId = x.CategoryId
                
        }).FirstOrDefault();
        return dto;
        
    }

    
}