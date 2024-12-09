using ProductApp.Dtos;

namespace ProductApp.Services.Interfaces;

public interface IArtistService
{
    Task AddAsync(ArtistDto dto);
    Task UpdateAsync(ArtistDto dto);
    Task DeleteAsync(long id); 
}