using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Dto;
using ProductApp.Entities;
using ProductApp.Services.Interfaces;

namespace ProductApp.Services;

public class ProductService: IProductService
{
    public ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async  Task Create(ProductDto dto)
    {
        var product = new Product()
        {
            Name = dto.Name,
            Price = dto.Price,
            Description = dto.Description,
            CategoryId =   dto.CategoryId

        };
        _context.Products.Add(product);
        

        await _context.SaveChangesAsync();

    }

    public async Task Edit(ProductDto dto)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == dto.Id);
        product.Name = dto.Name;
        product.Price = dto.Price;
        product.CategoryId = dto.CategoryId;
        product.Description = dto.Description;

        await _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        _context.Products.Remove(product);

        await _context.SaveChangesAsync();
    }
}