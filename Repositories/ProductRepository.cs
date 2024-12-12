using ProductApp.Data;
using ProductApp.Dto;
using ProductApp.Entities;
using ProductApp.Repositories.Interfaces;

namespace ProductApp.Repositories;

public class ProductRepository: IProductRepository
{
    public ApplicationDbContext _context;        //Field created

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    //fetch all the data from Products (CategoryID)
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
    //fetch all the data from Products (provide different mapping such category name can be directly use)
    public IQueryable<Product> GetQueryable()
    {
        return _context.Products;
    }
    
    //fetech product through their Id
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