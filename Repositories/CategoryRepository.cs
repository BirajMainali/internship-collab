using ProductApp.Data;
using ProductApp.Dto;
using ProductApp.Repositories.Interfaces;

namespace ProductApp.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public  List<CategoryDto> GetAll()
    {
        var dto = _context.Categories.Select(x=>new CategoryDto
        {
            Id = x.Id,
            Name = x.Name,
            Description=x.Description
        }).ToList();
        return dto;
    }

    public CategoryDto GetById(long id)
    {
        var dto = _context.Categories.Where(x => x.Id == id).Select(x => new CategoryDto
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description
        }).FirstOrDefault();
        return dto;
    }
}