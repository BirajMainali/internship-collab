using ProductApp.Entities;

namespace ProductApp.Repositories.Interfaces;

public interface ICourseRepo
{
    Task<IEnumerable<Course>> GetAllAsync();
    Task<Course?> GetByIdAsync(long id);
    Task AddAsync(Course course);
    Task UpdateAsync(Course course);
    Task DeleteAsync(long id);
}