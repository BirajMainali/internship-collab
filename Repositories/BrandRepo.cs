using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Entities;
using ProductApp.Repositories.Interfaces;

namespace ProductApp.Repositories;

public class BrandRepo:IBrandRepo
{
    private readonly AppDbContext _context;

    public BrandRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Brand>> GetAllAsync()
    {
        return await _context.Brands.ToListAsync();
    }

    // Get Brand by Id
    public async Task<Brand?> GetByIdAsync(long id)
    {
        return await _context.Brands.FirstOrDefaultAsync(c => c.Id == id);
    }
}