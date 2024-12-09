using ProductApp.Entities;

namespace ProductApp.Repositories.Interfaces;

public interface ISongRepo
{
    Task<List<Song>> GetAllWithArtistsAsync();
    Task<Song?> GetByIdAsync(long id);
}