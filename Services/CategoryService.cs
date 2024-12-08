using ProductApp.Data;
using ProductApp.Dto;
using ProductApp.Entities;
using ProductApp.Services.Interfaces;

namespace ProductApp.Services;

public class CategoryService:ICategoryService
{
    public ApplicationDbContext _context;

    public CategoryService(
        ApplicationDbContext context
    )
    {
        _context = context;
    }
    public async Task<Category> Create(CategoryDto dto)
    {
        var category = new Category()
        {
            Name = dto.Name,
            Description = dto.Description
        };
        await _context.Categories.AddAsync (category); 
       await _context.SaveChangesAsync();
       return category;
    }

    public async Task<Category > Edit(CategoryDto dto)
    {
        var category=_context.Categories.FirstOrDefault(categories=>categories.Id==dto.Id);
        category.Name = dto.Name;
        category.Description = dto.Description;
        await _context.SaveChangesAsync();
        return category;
    }

   

    public void Delete(long id)
    {
        var hasfoods=_context.Foods.Any(f=>f.CategoryId==id);
        if (hasfoods)
        {
            throw new InvalidOperationException("cannot delete category because it is associated with food ");
        }
        
        var category = _context.Categories.Find(id);
        if (category == null)
        {
            throw new KeyNotFoundException("category not found ");
        }
        _context.Categories.Remove(category);
        _context.SaveChanges();
    }
}