using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Entities;
using ProductApp.Repositories.Interfaces;

namespace ProductApp.Repositories;

public class PhoneRepo:IPhoneRepo
{
    private readonly AppDbContext _context;

    public PhoneRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Phone>> GetAllAsync()
    {
        return await _context.Phones.ToListAsync();
    }

    // Get Phones by Id
    public async Task<Phone?> GetByIdAsync(long id)
    {
        return await _context.Phones.FirstOrDefaultAsync(c => c.Id == id);
    }
}