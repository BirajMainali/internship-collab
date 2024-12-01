using ProductApp.Data;
using ProductApp.Dto;
using ProductApp.Repositories.Interfaces;

namespace ProductApp.Repositories;

public class FoodRepository:IFoodRepository
{
    public ApplicationDbContext _context;

    public FoodRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<FoodDto> GetAll()
    {
        var dto = _context.Foods.Select(x => new FoodDto
        {
            Id = x.Id,
            Name = x.Name,
            Price = x.Price,
            Description = x.Description,
            CategoryId = x.CategoryId

        }).ToList();
        return dto;




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