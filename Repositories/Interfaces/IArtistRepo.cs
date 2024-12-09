using ProductApp.Entities;

namespace ProductApp.Repositories.Interfaces;

public interface IArtistRepo
{
    Task<List<Artist>> GetAllAsync();
    Task<Artist?> GetByIdAsync(long id);
}