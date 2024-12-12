using ProductApp.Entities;

namespace ProductApp.Repositories.Interfaces;

public interface ICourseRepo
{
    Task<List<Course>> GetAllAsync();
    Task<Course> GetByIdAsync(long id);
}