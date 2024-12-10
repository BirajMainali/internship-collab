using ProductApp.Data;
using ProductApp.Dtos;
using ProductApp.Entities;
using ProductApp.Repositories.Interfaces;
using ProductApp.Services.Interfaces;

namespace ProductApp.Services;

public class SongService : ISongService
{
    private readonly AppDbContext _context;

    public SongService(AppDbContext context)
    {
        _context = context;
    }
    
     // Create song
    public async Task AddAsync(SongDto dto)
    {
        var song = new Song
        {
            Title = dto.Title,
            Genre = dto.Genre,
            ArtistId = dto.ArtistId
        };

        _context.Songs.Add(song);
        await _context.SaveChangesAsync();
    }

    // Edit song
    public async Task UpdateAsync(SongDto dto)
    {
        var song = await _context.Songs.FindAsync(dto.Id);

        if (song != null)
        {
            song.Title = dto.Title;
            song.Genre = dto.Genre;
            song.ArtistId = dto.ArtistId;

            _context.Songs.Update(song);
            await _context.SaveChangesAsync();
        }
    }

    // Delete song
    public async Task DeleteAsync(long id)
    {
        var song = await _context.Songs.FindAsync(id);

        if (song != null)
        {
            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
        }
    }
    
}