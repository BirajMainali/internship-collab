using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Entities;
using ProductApp.Repositories.Interfaces;

namespace ProductApp.Repositories;

public class ArtistRepo : IArtistRepo
{
    private readonly AppDbContext _context;

    // constructor
    public ArtistRepo(AppDbContext context)              
    {
        _context = context;
    }

    public async Task<List<Artist>> GetAllAsync()
    {
        return await _context.Artists.ToListAsync();
    }

    public async Task<Artist?> GetByIdAsync(long id)
    {
        return await _context.Artists.FirstOrDefaultAsync(a => a.Id == id);
    }
}