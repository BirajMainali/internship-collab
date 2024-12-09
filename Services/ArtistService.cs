using ProductApp.Data;
using ProductApp.Dtos;
using ProductApp.Entities;
using ProductApp.Services.Interfaces;

namespace ProductApp.Services;

public class ArtistService : IArtistService
{
    private readonly AppDbContext _context;

    // constructor
    public ArtistService(AppDbContext context)
    {
        _context = context;
    }

    // create artist
    public async Task AddAsync(ArtistDto dto)
    {
        var artist = new Artist
        {
            Id = dto.Id,
            Name = dto.Name
        };

        _context.Artists.Add(artist);
        await _context.SaveChangesAsync();
    }

    // edit artist
    public async Task UpdateAsync(ArtistDto dto)
    {
        var artist = await _context.Artists.FindAsync(dto.Id);

        if(artist != null)
        {
            artist.Name = dto.Name;

            _context.Artists.Update(artist);
            await _context.SaveChangesAsync(); 
        };
    }

    public async Task DeleteAsync(long id)
    {
        var artist = await _context.Artists.FindAsync(id);

        if(artist != null)
        {
            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync(); 
        };
    }
}