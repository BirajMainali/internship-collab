using ProductApp.Entities;

namespace ProductApp.Repositories.Interfaces;

public interface IStudentRepo
{
    Task<IEnumerable<Student>> GetAllAsync();
    Task<Student?> GetByIdAsync(long id);
    Task AddAsync(Student student);
    Task UpdateAsync(Student student);
    Task DeleteAsync(long id);
}