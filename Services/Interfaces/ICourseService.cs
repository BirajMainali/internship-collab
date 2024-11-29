using ProductApp.DTOs;

namespace ProductApp.Services.Interfaces;

public interface ICourseService
{
    Task AddAsync(CourseDto course);
    Task UpdateAsync(CourseDto course);
    Task DeleteAsync(long id);
}