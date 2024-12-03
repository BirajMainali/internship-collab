using ProductApp.Data;
using ProductApp.Dto;
using ProductApp.Entities;
using ProductApp.Repositories.Interfaces;

namespace ProductApp.Repositories;

public class ProductRepository: IProductRepository
{
    public ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<ProductDto> GetAll()
    {
        
        var dto = _context.Products.Select(x=>new ProductDto()
        {
            Id = x.Id,
            Name = x.Name,
            Description=x.Description,
            CategoryId = x.CategoryId,
            Price = x.Price,
            
        }).ToList();
        return dto;
        
    }

    public ProductDto GetById(long id)
    {
        var product = _context.Products.Find(id);
        var dto = new ProductDto()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            CategoryId = product.CategoryId,
            Price = product.Price,
        };
        return dto;
    }
}