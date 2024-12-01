using ProductApp.DTOs;

namespace ProductApp.Services.Interfaces;

public interface IStudentService
{
    Task AddAsync(StudentDto dto);
    Task UpdateAsync(StudentDto dto);
    Task DeleteAsync(long id);
}