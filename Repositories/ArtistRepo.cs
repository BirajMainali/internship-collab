using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Entities;
using ProductApp.Repositories.Interfaces;

namespace ProductApp.Repositories;

public class SongRepo : ISongRepo
{
    private readonly AppDbContext _context;

    public SongRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Song>> GetAllWithArtistsAsync()
    {
        return await _context.Songs.Include(s => s.Artist).ToListAsync();
    }

    public async Task<Song?> GetByIdAsync(long id)
    {
        return await _context.Songs.Include(s => s.Artist).FirstOrDefaultAsync(s => s.Id == id);
    }
}