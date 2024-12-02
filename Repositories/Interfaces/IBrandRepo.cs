using ProductApp.Entities;

namespace ProductApp.Repositories.Interfaces;

public interface IBrandRepo
{
    Task<List<Brand>> GetAllAsync();
    Task<Brand?> GetByIdAsync(long id);
}