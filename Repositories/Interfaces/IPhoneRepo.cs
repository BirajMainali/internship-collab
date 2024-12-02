using ProductApp.Entities;

namespace ProductApp.Repositories.Interfaces;

public interface IPhoneRepo
{
    Task<List<Phone>> GetAllAsync();
    Task<Phone?> GetByIdAsync(long id);
    
}