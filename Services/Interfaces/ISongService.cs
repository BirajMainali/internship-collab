using ProductApp.Dtos;

namespace ProductApp.Services.Interfaces;

public interface ISongService
{
    Task AddAsync(SongDto dto);
    Task UpdateAsync(SongDto dto);
    Task DeleteAsync(long id);
}