using ProductApp.DTOs;
using ProductApp.ViewModels;

namespace ProductApp.Services.Interfaces;

public interface IStudentService
{
    Task AddAsync(StudentDto dto);
    Task UpdateAsync(StudentDto dto);
    Task DeleteAsync(long id);
}