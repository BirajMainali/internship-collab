using ProductApp.Entities;

namespace ProductApp.Repositories.Interfaces;

public interface IStudentRepo
{
    Task<List<Student>> GetAllAsync();
    Task<Student?> GetByIdAsync(long id);
}